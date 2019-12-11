using Microsoft.Extensions.Configuration;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace STSys.Core.Data.Context
{
    public partial class NASysDapperContext: IDbContext
    {
        private readonly IConfiguration _configuration;
        public NASysDapperContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public DbConnectionFactory DbConnections
        {
            get
            {
                var factory = new DbConnectionFactory(_configuration);
                factory.CreateConnection();
                return factory;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
