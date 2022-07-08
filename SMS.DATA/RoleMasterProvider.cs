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
        //public WebpagesUserRole GetRolesById(int id)
        //{
        //    return _db.WebpagesUserRoles.Find(id);
        //}
        public WebpagesRole GetRolesById()
        {
            var userId = (from user in _db.signups
                          where user.Email == SessionHelper.Email
                          select user.Userid).FirstOrDefault();
           
           return _db.WebpagesRoles.Find(userId);
        }
        public List<WebpagesRole> GetAllRoles()
        {
            //var data = (from a in _db.WebpagesRoles
            //            select new WebpagesRole
            //            {
            //                RoleId = a.RoleId,
            //                RoleName = a.RoleName,
            //                RoleCode = a.RoleCode,
            //                IsActive = a.IsActive
            //            }).ToList();

            return _db.WebpagesRoles.ToList();
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
