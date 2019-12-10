using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace STSys.Core.Data.Context.Config
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection(string index);
        DbConnection GetFirstConnection();
    }
}
