using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using STSys.Core.Data.Context.Interfaces;
using MongoDB.Driver;

namespace STSys.Core.Data.Context.Config
{
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private static IDictionary<string, DbConnection> DbConnection;
        private readonly string _connectionString, _connectionWriteString;
        private readonly IMongoDatabase _mongodbDatabase = null;
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionWriteString = configuration.GetConnectionString("DefaultConnectionWrite");
            DbConnection = new Dictionary<string, DbConnection>() {
                    { "read",new SqlConnection(_connectionString)},
                    { "write",new SqlConnection(_connectionWriteString)}
            };
            this._configuration = configuration;
            var mongodbConfig = _configuration["mongo:connectionString"];
            if (mongodbConfig != null)
            {
                var client = new MongoClient(mongodbConfig);
                if (client != null)
                    _mongodbDatabase = client.GetDatabase(configuration["mongo:databaseName"]);
            }
        }

        public DbConnection this[string index]
        {
            get
            {
                return DbConnection[index];
            }
        }
        public DbConnection GetFirstConnection
        {
            get
            {
                return DbConnection.Values.First();
            }
        }

        public IMongoDatabase GetMongoDatabase
        {
            get
            {
                return _mongodbDatabase;
            }
        }



        public string Provider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DbConnection GetConnection(string index)
        {
            return DbConnection[index];
        }

        public DbConnection GetRandomConnection()
        {
            throw new NotImplementedException();
        }

        DbConnection IDbConnectionFactory.GetFirstConnection()
        {
            return DbConnection.Values.First();
        }
    }
}
