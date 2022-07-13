using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class TeacherController : Controller
    {
        public readonly TeacherService teacherService;
        public TeacherController()
        {
            teacherService = new TeacherService();
        }
        // GET: Teacher
        public ActionResult Index()
        {
            List<Teacher> teachers = teacherService.GetAllTeacher();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult AddTeacher()
        {
            Teacher T1 = new Teacher();
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

            teacherService.DeleteTeacher(Id);
            return RedirectToAction("Index");
        }
    }
}