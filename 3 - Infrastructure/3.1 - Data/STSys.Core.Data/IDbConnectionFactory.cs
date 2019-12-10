using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace STSys.Core.Data
{
    public interface IDbConnectionFactory
    {
        string Provider { get; set; }
        DbConnection GetConnection(string index);
        DbConnection GetFirstConnection();
        DbConnection GetRandomConnection();
    }
}
