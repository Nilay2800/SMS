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
       

        public webpages_Roles GetRolesById(int Id)
        {
            //var data = roleMasterProvider.GetRolesById(Id);
            //webpages_Roles role = new webpages_Roles()
            //{
            //    RoleId = data.RoleId,
            //    RoleName = data.RoleName,
            //    RoleCode = data.RoleCode,
            //    IsActive = data.IsActive
            //};
            //return role;

            return roleMasterProvider.GetRolesById(Id);
        }
        public webpages_Roles GetRolesByName(string roleName)
        {
            return roleMasterProvider.GetRolesByName(roleName);
        }

        public webpages_Roles CreateRole(webpages_Roles role)
        {
            return roleMasterProvider.CreateRole(role);
        }
    }
}
