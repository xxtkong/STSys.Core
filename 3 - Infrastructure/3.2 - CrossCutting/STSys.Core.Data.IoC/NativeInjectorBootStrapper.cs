using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.CrossCutting.Bus;
using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Context.Interfaces;
using STSys.Core.Data.Repository;
using STSys.Core.Data.Repository.Admin;
using STSys.Core.Data.Repository.Dapper.Common;
using STSys.Core.Data.Repository.EntityFramework.Common;
using STSys.Core.Data.Repository.MongoDB;
using STSys.Core.Data.Repository.Users;
using STSys.Core.Domain.Core.Bus;
using STSys.Core.Domain.Interfaces.Mediator;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Commands;
using STSys.Core.Users.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace STSys.Core.Data.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddNativeInjectorBootStrapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUnitOfWork<STSysContext>()
            .AddScoped<IMediatorHandler, InMemoryBus>()
            .AddMediatR(typeof(UsersInsertCommand).GetTypeInfo().Assembly)
            .AddScoped(typeof(IRepository<>), typeof(DapperRepository<>))
            .AddScoped(typeof(IRepositoryEF<>), typeof(Repository<>))
            .AddScoped(typeof(IRepositoryMongoDB<>), typeof(RepositoryMongoDB<>))
            .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IManagerRepository, ManagerRepository>()
            .AddScoped<IColumnRepository, ColumnRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IDbContext, NASysDapperContext>()
            ;

        }
        
        public static void AddEFDefaultDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //SqlServer
            services.AddDbContext<STSysContext>(options => options.UseSqlServer(configuration.GetConnectionString("EFConnection")));
            //mysql
            //services.AddDbContext<STSysContext>(options => options.UseMySql(configuration.GetConnectionString("MySqlConnection")));
        }
        public static void AddDapperDefaultDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        }

        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var factory = new MongodbFactory(configuration);
            services.AddSingleton(factory);
            return services;
        }
    }
}
