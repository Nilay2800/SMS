using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class RoleMasterProvider:BaseProvider
    {
        public RoleMasterProvider()
        {

        }
        
        public WebpagesRole GetRolesById(int Id)
        {
            return _db.WebpagesRoles.Find(Id);
        }
        public List<RoleModel> GetAllRoles()
        {
            var data = (from a in _db.WebpagesRoles
                        select new RoleModel
                        {
                            Id = a.RoleId,
                            Name = a.RoleName,
                            RoleCode = a.RoleCode,
                            IsActive = a.IsActive
                        }).ToList();

            return data;
        }
        public WebpagesRole GetRolesByName(string roleName)
        {
            return _db.WebpagesRoles.Where(x => x.RoleName == roleName).FirstOrDefault();
        }
        public WebpagesRole CreateRole(WebpagesRole role)
        {
            WebpagesRole _webpages_Roles = new WebpagesRole()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleCode = role.RoleCode,
                IsActive = role.IsActive,
                
            };

            _db.WebpagesRoles.Add(_webpages_Roles);
            _db.SaveChanges();

            return role;
        }

    }
}
