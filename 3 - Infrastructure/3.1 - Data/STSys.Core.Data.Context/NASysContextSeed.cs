using Microsoft.Extensions.Logging;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Data.Context
{
    public class STSysContextSeed
    {
        public static async Task SeedAsync(STSysContext catalogContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {

                if (!catalogContext.Users.Any())
                {
                    catalogContext.Users.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        static IEnumerable<UsersEntities> GetPreconfiguredItems()
        {
            return new List<UsersEntities>()
            {
                //new Users(){ Mobile = "13512341234" , Balance = 1000, CreateTime = DateTime.Now, Pwd = "123456", Status = 1, UseBalance = 800, Encrypt = "123"}
            };
        }
    }
}
