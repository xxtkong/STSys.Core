using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
