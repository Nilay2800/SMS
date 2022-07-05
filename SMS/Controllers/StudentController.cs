using SMS.Model;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        public ActionResult Index(/*int? Page,*/ Guid? studentId)
        {
            List<Student> studentlist = _studentService.GetallStudent().ToList();
            studentlist = _studentService.GetallStudent().ToList();
            if (studentId == null)
            {
                studentlist = _studentService.GetallStudent().ToList();
            }
            else
            {
                studentlist = _studentService.GetallStudent().Where(a => a.StudentId == studentId).ToList();
            }
            return View(studentlist);/*.ToPagedList(Page ? 1, 10));*/
        }
        public ActionResult Create()
        {
            Student s1 = new Student();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentService.CreateStudent(student);
            return RedirectToAction("Index", "Student");
        }
        [HttpGet]
        public ActionResult Edit(Guid StudentId)
        {
            Student s2 = _studentService.GetStudentById(StudentId);
            return View(StudentId);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Student s2 = _studentService.UpdateStudent(student);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid studentId)
        {
            Student s3 = _studentService.GetStudentById(studentId);
            return RedirectToAction("Index");        
        }
        
    }
}