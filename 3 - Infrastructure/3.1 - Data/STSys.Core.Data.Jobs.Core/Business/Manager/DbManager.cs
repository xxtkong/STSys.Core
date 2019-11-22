using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.IO;

namespace STSys.Core.Data.Jobs.Business.Manager
{
    public class DbManager
    {
        public readonly IConfiguration configuration;

        public DbManager()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.Test.json", true, reloadOnChange: true);
            configuration = builder.Build();
        }
        private string ConnectionString
        {
            get
            {
                return configuration["SqlSugarDB:connectionString"];
            }
        }

        private string DbType
        {
            get
            {
                return configuration["SqlSugarDB:DbType"]; ;
            }
        }

        public SqlSugarClient Getdb()
        {
            SqlSugarClient _db = null;

            if (DbType.ToLower() == "mysql")
            {
                _db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString, DbType = SqlSugar.DbType.MySql, IsAutoCloseConnection = true });
            }
            else if (DbType.ToLower() == "sqlserver")
            {
                _db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString, DbType = SqlSugar.DbType.SqlServer, IsAutoCloseConnection = true });
            }
            else
            {
                throw new Exception("DbType:" + DbType + " 未知");
            }

            _db.Ado.IsEnableLogEvent = false;

            if (_db != null)
            {
                string BackgroundJobMappingDbTable = GetDbTableNameSetting("BackgroundJobMappingDbTable");
                BackgroundJobMappingDbTable = string.IsNullOrWhiteSpace(BackgroundJobMappingDbTable) ? "BackgroundJob" : BackgroundJobMappingDbTable;
                _db.MappingTables.Add("BackgroundJobInfo", BackgroundJobMappingDbTable);

                string BackgroundJobLogMappingDbTable = GetDbTableNameSetting("BackgroundJobLogMappingDbTable");
                BackgroundJobLogMappingDbTable = string.IsNullOrWhiteSpace(BackgroundJobLogMappingDbTable) ? "BackgroundJobLog" : BackgroundJobLogMappingDbTable;
                _db.MappingTables.Add("BackgroundJobLogInfo", BackgroundJobLogMappingDbTable);

            }
            return _db;
        }

        private string GetDbTableNameSetting(string dbName)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(dbName);
        }
    }
}
