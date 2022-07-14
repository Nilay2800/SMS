using SMS.Data.Database;
using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class UserMasterController : BaseController
    {
        private readonly UserMasterService userMasterService;
        public UserMasterController()
        {
            userMasterService = new UserMasterService();
        }
        // GET: UserMaster
        public ActionResult DisplayUser()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Usermaster.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            List<Signups> UserList = userMasterService.GetAllUser();
            return View(UserList);
        }
        public ActionResult EditUserRoleMapping(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Usermaster.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            StudentEntites _db = new StudentEntites();
            ViewBag.RoleList = userMasterService.BindRole();
            Signups user = userMasterService.GetUserById(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUserRoleMapping(Signups pur)
        {
            Signups objPurchaseModel = userMasterService.UpdateUsersRole(pur);
            return RedirectToAction("DisplayUser");
        }
    
        public ActionResult DeleteUser(int id, Signups user)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Usermaster.ToString(), AcessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            userMasterService.DeleteUser(id);
            return RedirectToAction("DisplayUser");
        }

    }
}