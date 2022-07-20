using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class TeacherController : BaseController
    {
        public readonly TeacherService teacherService;
        public TeacherController()
        {
            teacherService = new TeacherService();
        }
        // GET: Teacher
        public ActionResult Index()
        {
           
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Teacher.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
             List<Teacher> teachers = teacherService.GetAllTeacher();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult AddTeacher()
        {
            Teacher T1 = new Teacher();
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Teacher.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            return View();
        }


        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {
            teacherService.CreateTeacher(teacher);
            return RedirectToAction("Index","Teacher");
        }
        [HttpGet]
        public ActionResult EditTeacher(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Teacher.ToString(), AcessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Teacher teacherModel = teacherService.GetTeacherById(id);
            return View(teacherModel);
        }


        [HttpPost]
        public ActionResult EditTeacher(Teacher teacherModel)
        {
            Teacher teacherModel1 = teacherService.UpdateTeacher(teacherModel);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Teacher.ToString(), AcessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            teacherService.DeleteTeacher(Id);
            return RedirectToAction("Index");
        }
    }
}