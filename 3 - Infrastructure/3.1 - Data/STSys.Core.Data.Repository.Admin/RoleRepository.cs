using Microsoft.EntityFrameworkCore;
using STSys.Core.Admin.Abstractions.Entities;
using STSys.Core.Admin.Abstractions.Interfaces;
using STSys.Core.Data.Context;
using STSys.Core.Data.Context.Config;
using STSys.Core.Data.Context.Interfaces;
using STSys.Core.Data.Repository.EntityFramework.Common;
using STSys.Core.Domain.Core.Common;
using STSys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Data.Repository.Admin
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        private readonly IRepositoryEF<RelevanceRoleEntity> _repositoryEF;
        private readonly IRepositoryEF<ModuleElementEntity> _moduleElementRepository;
        private readonly IRepositoryEF<RelevanceElementEntity> _relevanceElementRepository;

        private readonly IUnitOfWork _unitOfWork;

        public RoleRepository(STSysContext dbContext, IRepositoryEF<RelevanceRoleEntity> repositoryEF, IUnitOfWork unitOfWork, IRepositoryEF<ModuleElementEntity> moduleElementRepository, IRepositoryEF<RelevanceElementEntity> relevanceElementRepository) : base(dbContext)
        {
            this._repositoryEF = repositoryEF;
            this._unitOfWork = unitOfWork;
            this._moduleElementRepository = moduleElementRepository;
            this._relevanceElementRepository = relevanceElementRepository;
        }
        public void Assign(Guid managerId, Guid roleId, Guid uid, bool ischecked)
        {
            if (ischecked)
                _repositoryEF.Insert(new RelevanceRoleEntity() { Id = Guid.NewGuid(), ManagerId = managerId, OperatorId = uid, OperateTime = DateTime.Now, RoleId = roleId, Description = "增加权限" });
            else
                _repositoryEF.Delete(s => s.ManagerId.Equals(managerId) && s.RoleId.Equals(roleId));
            _unitOfWork.Commit();
        }

        public IQueryable<LoginRoleDto> GetCurrentUser(Guid userid)
        {

            var query = from q in this._dbContext.RelevanceElement
                        where (_dbContext.RelevanceRole.
                             Where(s => s.ManagerId.Equals(userid) && s.RoleEntity.Status == (int)CommonState.正常).Select(s => s.RoleId)).Contains(q.RoleId)
                        select new LoginRoleDto { moduleElements = q.ModuleElementEntity, modules = q.ModuleEntity };

            return query;
        }

        public Tuple<IQueryable<RoleEntity>, IQueryable<RelevanceRoleEntity>> GetMany(Guid managerId)
        {
            var roles = GetAll();
            var relevanceRole = _repositoryEF.GetMany(s=>s.ManagerId == managerId);
            return new Tuple<IQueryable<RoleEntity>, IQueryable<RelevanceRoleEntity>>(roles, relevanceRole);
        }

        public Tuple<IQueryable<ModuleElementEntity>, IQueryable<RelevanceElementEntity>> LoadElement(Guid roleId,Guid moduleId)
        {
            var moduleElement = _moduleElementRepository.GetMany(s => s.ModuleId.Equals(moduleId));
            var relevanceElement = _relevanceElementRepository.GetMany(s => s.ModuleId.Equals(moduleId) && s.RoleId.Equals(roleId));
            return new Tuple<IQueryable<ModuleElementEntity>, IQueryable<RelevanceElementEntity>>(moduleElement, relevanceElement);
        }

        public void SaveAssign(Guid roleId, Guid elementId, Guid moduleId, Guid managerId, bool ischecked)
        {
            if (ischecked)
                _relevanceElementRepository.Insert(new RelevanceElementEntity() { ElementId = elementId, ModuleId = moduleId, OperateTime = DateTime.Now, OperatorId = managerId, RoleId = roleId, Status = (int)CommonState.正常, Description = "设置权限" });
            else
                _relevanceElementRepository.Delete(s => s.RoleId.Equals(roleId) && s.ElementId.Equals(elementId));
            _unitOfWork.Commit();
        }
    }
}
