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
        public List<WebpagesRole> GetAllRoles()
        {
            var roles = roleMasterProvider.GetAllRoles();
            return roles;
        }
        //public WebpagesRole GetRolesById(int id)
        //{
        //    return roleMasterProvider.GetRolesById(id);
        //}

        public WebpagesRole GetRolesById()
        {
            var data = roleMasterProvider.GetRolesById();
            WebpagesRole role = new WebpagesRole()
            {
                RoleId = data.RoleId,
                RoleName = data.RoleName,
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
