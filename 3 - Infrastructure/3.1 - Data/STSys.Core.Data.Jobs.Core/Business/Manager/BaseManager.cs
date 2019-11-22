using SqlSugar;
using System;

namespace STSys.Core.Data.Jobs.Business.Manager
{
    public class BaseManager
    {
        public SqlSugarClient db
        {
            get
            {
                return new DbManager().Getdb();
            }
        }
    }
}
