using STSys.Core.Data.Jobs.Business.Info;
using STSys.Core.Data.Jobs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Jobs.Business.Manager
{
    public class UsersManager : BaseManager
    {
      
        public Users Login(string userName, string pwd)
        {
            var users = db.Queryable<Users>().Where(s => s.Account.Equals(userName));
            if(users.Count()>0)
            {
                var user = users.First();
                var encrypt = user.Encrypt;
                var encodepassword = Cryptographer.EncodePassword(pwd, 1, user.Encrypt);
                if (user.Password == encodepassword)
                {
                    return user;
                }
            }
            return default(Users);
        }
    }
}
