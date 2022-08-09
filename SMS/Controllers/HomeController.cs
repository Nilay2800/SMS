using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly StudentService studentService;
        private readonly TeacherService teacherService;
        private readonly AnnoucementService annoucementService;
        public HomeController()
        {
            studentService = new StudentService();
            teacherService = new TeacherService();
            annoucementService = new AnnoucementService();
        }
        public ActionResult Index()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Home.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            ViewBag.TotalStudent = studentService.TotalStudent();
            ViewBag.TotalTeacher = teacherService.TotalTeacher();
            ViewBag.TotalAnnouncement = annoucementService.TotalAnnouncement();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}