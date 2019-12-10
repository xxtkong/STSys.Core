using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context.Config
{
    public class MongodbFactory
    {
        private readonly IMongoDatabase _mongodbDatabase = null;
        public IMongoDatabase GetMongoDatabase
        {
            get
            {
                return _mongodbDatabase;
            }
        }
        public MongodbFactory(IConfiguration configuration)
        {
            var mongodbConfig = configuration["mongo:connectionString"];
            if (mongodbConfig != null)
            {
                var client = new MongoClient(mongodbConfig);
                if (client != null)
                    _mongodbDatabase = client.GetDatabase(configuration["mongo:databaseName"]);
            }
        }
    }
}
