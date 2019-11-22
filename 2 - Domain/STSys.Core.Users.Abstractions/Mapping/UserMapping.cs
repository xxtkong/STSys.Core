using DapperExtensions.Mapper;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Mapping
{
    public class UserMapping : ClassMapper<UsersEntities>
    {
        public UserMapping()
        {
            Table("Users");
            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            AutoMap();
        }
    }
}
