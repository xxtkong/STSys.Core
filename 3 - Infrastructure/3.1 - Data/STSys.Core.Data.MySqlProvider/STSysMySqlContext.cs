using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.EntityMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace STSys.Core.Data.MySqlProvider
{
    public class STSysMySqlContext: DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly AssemblyOptions _assemblyOptions;
        public STSysMySqlContext(DbContextOptions<STSysMySqlContext> options, IConfiguration configuration, IOptions<AssemblyOptions> assemblyOptions) : base(options)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MySqlConnection");
            _assemblyOptions = assemblyOptions.Value;
        }
        /// <summary>
        /// Add-Migration updatedb
        /// Update-Database -Context STSysContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                }
            }
        }
        /// <summary>
        /// 配置EFCore 贪婪加载
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
