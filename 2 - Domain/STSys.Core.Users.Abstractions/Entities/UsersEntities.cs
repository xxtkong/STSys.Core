using STSys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Users.Abstractions.Entities
{
    public class UsersEntities : Entity
    {
        protected UsersEntities()
        {
        }
        public UsersEntities(Guid id, string userName, string password, string name, string email, DateTime createTime, string mobile, int status, string picUrl, string encrypt)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Name = name;
            Email = email;
            CreateTime = createTime;
            Mobile = mobile;
            Status = status;
            PicUrl = picUrl;
            Encrypt = encrypt;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public string PicUrl { get; set; }
        public string Encrypt { get; set; }
        public decimal? Price { get; set; }
    }
}
