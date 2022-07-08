using SMS.Data;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class UserMasterService
    {
        private readonly UserMasterProvider userMasterProvider;
        public UserMasterService()
        {
            userMasterProvider = new UserMasterProvider();
        }
        public List<Signups> GetAllUser()
        {
            return userMasterProvider.GetAllUser();
        }

        public Signups GetUserById(int id)
        {
            return userMasterProvider.GetUserById(id);
        }

        public Signups UpdateUsersRole(Signups pur)
        {
            return userMasterProvider.UpdateUsersRole(pur);
        }

        public List<DropDownList> BindRole()
        {
            return userMasterProvider.BindRole();
        }

        public Signups DeleteUser(int id)
        {
            return userMasterProvider.DeleteUser(id);
        }
    }
}
