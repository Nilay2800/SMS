using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class RoleMasterController : Controller
    {
        private readonly RoleMasterService roleMasterService;

        public RoleMasterController()
        {
            roleMasterService = new RoleMasterService();
        }

        public ActionResult Index()
        {
            List<WebpagesRole> RoleList = roleMasterService.GetAllRoles();
            return View(RoleList);
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(WebpagesRole role)
        {
            roleMasterService.CreateRole(role);
            return RedirectToAction("Index");
        }
    }
}