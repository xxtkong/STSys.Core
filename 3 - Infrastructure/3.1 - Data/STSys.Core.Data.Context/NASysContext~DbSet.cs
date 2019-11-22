using Microsoft.EntityFrameworkCore;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Data.Context
{
    public partial  class STSysContext
    {
        public DbSet<UsersEntities> Users { get; set; }
        public DbSet<ManagerEntities> Manager { get; set; }
        public DbSet<ColumnEntity> Column { get; set; }
        public DbSet<IndexRecommendEntity> Recommend { get; set; }
        public DbSet<ModuleEntity> Module { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<RelevanceRoleEntity> RelevanceRole { get; set; }
        public DbSet<ModuleElementEntity> ModuleElement { get; set; }
        public DbSet<RelevanceElementEntity> RelevanceElement { get; set; }
    }
}
