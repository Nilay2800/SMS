using SMS.Data;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class RoleMasterService
    {
        public readonly RoleMasterProvider roleMasterProvider;
        public RoleMasterService()
        {
            roleMasterProvider = new RoleMasterProvider();
        }
        public List<RoleModel> GetAllRoles()
        {
            var roles = roleMasterProvider.GetAllRoles();
            return roles;
        }
       

        public RoleModel GetRolesById(int Id)
        {
            var data = roleMasterProvider.GetRolesById(Id);
            RoleModel role = new RoleModel()
            {
                Id = data.RoleId,
                Name = data.RoleName,
                RoleCode = data.RoleCode,
                IsActive = data.IsActive
            };
            return role;
        }
        public WebpagesRole GetRolesByName(string roleName)
        {
            return roleMasterProvider.GetRolesByName(roleName);
        }

        public WebpagesRole CreateRole(WebpagesRole role)
        {
            return roleMasterProvider.CreateRole(role);
        }
    }
}
