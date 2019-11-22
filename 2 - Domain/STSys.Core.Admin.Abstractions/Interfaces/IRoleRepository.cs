using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using STSys.Core.Admin.Abstractions.Entities;

namespace STSys.Core.Admin.Abstractions.Interfaces
{
    public interface IRoleRepository
    {
        Tuple<IQueryable<RoleEntity>, IQueryable<RelevanceRoleEntity>> GetMany(Guid managerId);
        void Assign(Guid managerId, Guid roleId, Guid uid, bool ischecked);

        Tuple<IQueryable<ModuleElementEntity>, IQueryable<RelevanceElementEntity>> LoadElement(Guid roleId, Guid moduleId);
        void SaveAssign(Guid roleId,Guid elementId,Guid moduleId,Guid managerId, bool ischecked);
        IQueryable<LoginRoleDto> GetCurrentUser(Guid userid);
    }
}
