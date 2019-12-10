using Microsoft.Extensions.Configuration;
using STSys.Core.Data.Context.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace STSys.Core.Data.Context
{
    public partial class STSysContext
    {
        public IDbConnection STSysDapperConnection
        {
            get { return new SqlConnection(_connectionString); }
        }
        public DbConnectionFactory DbConnections
        {
            get
            {
                return new DbConnectionFactory(_configuration);
            }
        }
    }
}
