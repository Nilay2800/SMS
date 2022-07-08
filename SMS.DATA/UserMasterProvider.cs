using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class UserMasterProvider:BaseProvider
    {
        public List<Signups> GetAllUser()
        {
            var User = _db.signups.ToList();
            return User;
        }

        public Signups GetUserById(int id)
        {
            return _db.signups.Find(id);
        }
        public Signups UpdateUsersRole(Signups pur)
        {
            UserRoleMapping _userRoleMapping = new UserRoleMapping();
            {
                _userRoleMapping.RoleId = pur.Role;
                _userRoleMapping.UserId = pur.Userid;
            }
            _db.UserRoleMappings.Add(_userRoleMapping);
            _db.SaveChanges();

            return pur;
        }
        public List<DropDownList> BindRole()
        {
            return _db.WebpagesRoles.Where(s => s.IsActive == true).Select(x => new DropDownList { Key = x.RoleName, Value = x.RoleId }).ToList();
        }

        public Signups DeleteUser(int id)
        {
            var s = _db.signups.Find(id);
            _db.signups.Remove(s);
            _db.SaveChanges();
            return s;
        }

    }
}
