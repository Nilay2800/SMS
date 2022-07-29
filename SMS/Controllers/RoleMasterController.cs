using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class RoleMasterController : BaseController
    {
        private readonly RoleMasterService roleMasterService;

        public RoleMasterController()
        {
            roleMasterService = new RoleMasterService();
        }

        public ActionResult Index()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Rolemaster.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            ViewBag.Permission = GetPermission(AuthorizeFormAccess.FormAccessCode.Rolemaster.ToString());
            List<RoleModel> RoleList = roleMasterService.GetAllRoles();
            return View(RoleList);
        }
        public ActionResult CreateRole()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Rolemaster.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(webpages_Roles role)
        {
            roleMasterService.CreateRole(role);
            return RedirectToAction("Index");
        }
    }
}