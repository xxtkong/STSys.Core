using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using STSys.Core.Data.Context.Config;
using STSys.Core.Users.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context
{
    public partial class STSysContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public STSysContext(DbContextOptions<STSysContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        /// <summary>
        /// Add-Migration updatedb
        /// Update-Database -Context STSysContext
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManagerEFMapping());
            //modelBuilder.EnableAutoHistory(null);
            modelBuilder.Entity<ManagerEntities>().HasData(new ManagerEntities()
            {
                Id = Guid.NewGuid(),
                 Account = "xxtk",
                  Address = "重庆",
                   CreateTime = DateTime.Now,
                    Email = "xxtk@163.com",
                     Encrypt = "123",
                       Mobile = "13512341234",
                        Name = "张三",
                         Password = "CBC33BED3530501DCE65D6FD65C669222A0EDA521A56E3B90489E71FB3EE142E",
                          PicUrl = "",
                           QQ ="123456",
                            Status = 0
            });
        }
        /// <summary>
        /// 配置EFCore 贪婪加载
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}
