using STSys.Core.Data.Context.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context.Interfaces
{
    public interface IDbContext
    {
        DbConnectionFactory DbConnections { get;}
        void Dispose();
    }
}
