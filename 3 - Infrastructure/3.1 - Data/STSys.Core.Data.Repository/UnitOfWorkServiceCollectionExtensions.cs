using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using STSys.Core.Data.Context.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Repository
{
    public static class UnitOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            return services;
        }
    }
}
