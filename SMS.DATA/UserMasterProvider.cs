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
            
            var currentUser = _db.signups.Find(id);

            var roleid = (from rolemapping in _db.UserRoleMappings
                            join role in _db.WebpagesRoles on rolemapping.RoleId equals role.RoleId
                            where rolemapping.UserId == currentUser.Userid
                            orderby rolemapping.id descending
                            select role.RoleId).FirstOrDefault();
            var User = new Signups()
            {
                Userid=currentUser.Userid,
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                RoleId = roleid 
            };
            return User;
        }
        public Signups UpdateUsersRole(Signups pur)
        {
            
            
                var v = _db.UserRoleMappings.Where(a => a.UserId == pur.Userid).FirstOrDefault();
                if (v != null)
                {
                    UserRoleMapping userRoleMapping = _db.UserRoleMappings.FirstOrDefault(x => x.id == v.id);
                    userRoleMapping.RoleId = pur.RoleId;
                    userRoleMapping.UserId = pur.Userid;
                    _db.SaveChanges();
                }
                else
                {
                     UserRoleMapping _userRoleMapping = new UserRoleMapping();
                    _userRoleMapping.RoleId = pur.RoleId;
                    _userRoleMapping.UserId = pur.Userid;
                    _db.UserRoleMappings.Add(_userRoleMapping);
                    _db.SaveChanges();
                }
            
            

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
        public Signups CreateUser(Signups user)
        {
           
            Signups obj = new Signups()
            {
                RoleId = user.RoleId,
                Userid = user.Userid,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                
            };
            _db.signups.Add(obj);
            _db.SaveChanges();
            return user;
        }
    }
}
