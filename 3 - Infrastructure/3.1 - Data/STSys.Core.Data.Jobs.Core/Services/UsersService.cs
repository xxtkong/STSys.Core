using STSys.Core.Data.Jobs.Business.Info;
using STSys.Core.Data.Jobs.Business.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Jobs.Services
{
    public class UsersService
    {
        public UsersService() { }

        /// <summary>
        /// 简单登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Users Login(string userName,string pwd)
        {
            return new UsersManager().Login(userName, pwd);
        }

    }
}
