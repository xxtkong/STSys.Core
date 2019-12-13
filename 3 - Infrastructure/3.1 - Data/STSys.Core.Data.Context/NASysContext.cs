using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using STSys.Core.Data.Context.Config;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.EntityMapper;
using STSys.Core.Product.Abstractions.Entities;
using STSys.Core.Product.Abstractions.Mapping;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace STSys.Core.Data.Context
{
    public partial class STSysContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly AssemblyOptions _assemblyOptions;

        public STSysContext(DbContextOptions<STSysContext> options, IConfiguration configuration, IOptions<AssemblyOptions> assemblyOptions) : base(options)
        {
            _configuration = configuration;
            _assemblyOptions = assemblyOptions.Value;
        }
        /// <summary>
        /// Add-Migration updatedb
        /// Update-Database -Context STSysContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductEFMapping());
            //modelBuilder.ApplyConfiguration(new ProductItemEFMapping());

            var domainAssembly = _assemblyOptions.DomainAssemblyName;
            foreach (var item in domainAssembly)
            {
                var entityTypes = Assembly.Load(new AssemblyName(item)).GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                .Where(type => type.GetTypeInfo().IsClass)
                .Where(type => type.GetTypeInfo().BaseType != null)
                .Where(type => typeof(IEntityMapper).IsAssignableFrom(type)).ToList();

                foreach (var entityType in entityTypes)
                {
                    modelBuilder.ApplyConfigurationsFromAssembly(entityType.Assembly);
                    //if (modelBuilder.Model.FindEntityType(entityType) != null)
                    //    continue;
                    //modelBuilder.Model.AddEntityType(entityType);
                }
            }

            //modelBuilder.ApplyConfiguration(new ManagerEFMapping());
            ////modelBuilder.EnableAutoHistory(null);
            //modelBuilder.Entity<ManagerEntities>().HasData(new ManagerEntities()
            //{
            //    Id = Guid.NewGuid(),
            //    Account = "xxtk",
            //    Address = "重庆",
            //    CreateTime = DateTime.Now,
            //    Email = "xxtk@163.com",
            //    Encrypt = "123",
            //    Mobile = "13512341234",
            //    Name = "张三",
            //    Password = "CBC33BED3530501DCE65D6FD65C669222A0EDA521A56E3B90489E71FB3EE142E",
            //    PicUrl = "",
            //    QQ = "123456",
            //    Status = 0
            //});
        }
        private void ConfigureBasket(EntityTypeBuilder<ProductEntities> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ProductEntities.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }




        /// <summary>
        /// 配置EFCore 贪婪加载，必须加virtual...注释后用 ISpecification
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}
