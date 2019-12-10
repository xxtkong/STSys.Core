﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using STSys.Core.Data.Context.Interfaces;
using MongoDB.Driver;
using MySql.Data.MySqlClient;

namespace STSys.Core.Data.Context.Config
{
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private static IDictionary<string, DbConnection> DbConnection = new Dictionary<string, DbConnection>();
        private readonly string _connectionString, _connectionWriteString;
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            string provider = configuration.GetConnectionString("SQLProvider") ?? "mssql";
            switch (provider)
            {
                case "mssql":
                    _connectionString = configuration.GetConnectionString("DefaultConnection");
                    _connectionWriteString = configuration.GetConnectionString("DefaultConnectionWrite");
                    int i =0, j = 0;
                    foreach (var item in _connectionString.Split('&'))
                    {
                        if(!DbConnection.ContainsKey("read" + i))
                            DbConnection.Add("read"+i, new SqlConnection(item));
                        i++;
                    }
                    foreach (var item in _connectionWriteString.Split('&'))
                    {
                        if (!DbConnection.ContainsKey("write" + j))
                            DbConnection.Add("write"+j, new SqlConnection(item));
                        j++;
                    }
                    break;
                case "mysql":
                    _connectionString = configuration.GetConnectionString("MySqlConnection");
                    _connectionWriteString = configuration.GetConnectionString("MySqlConnectionWrite");
                    int r = 0, w = 0;
                    foreach (var item in _connectionString.Split('&'))
                    {
                        if (!DbConnection.ContainsKey("read" + r))
                            DbConnection.Add("read"+r, new MySqlConnection(item));
                        r++;
                    }
                    foreach (var item in _connectionWriteString.Split('&'))
                    {
                        if (!DbConnection.ContainsKey("write" + w))
                            DbConnection.Add("write"+w, new MySqlConnection(item));
                        w++;
                    }
                    break;
                default:
                    break;
            }
            this._configuration = configuration;
        }
        
        

        public DbConnection GetConnection(string index)
        {
            switch (index)
            {
                case "read":
                    return DbConnection.Where(s => s.Key.Contains("read")).OrderBy(_ => Guid.NewGuid()).First().Value;
                case "write":
                    return DbConnection.Where(s => s.Key.Contains("read")).OrderBy(_ => Guid.NewGuid()).First().Value;
                default:
                    return DbConnection.OrderBy(_ => Guid.NewGuid()).First().Value;
            }
        }

        public DbConnection GetFirstConnection()
        {
            return DbConnection.Values.First();
        }
    }
}
