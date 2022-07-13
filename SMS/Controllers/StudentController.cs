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
        public readonly StudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        public ActionResult Index( Guid? studentId)
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
            return View(studentlist);
        }
        public ActionResult Create()
        {
            Student s1 = new Student();
            return View(s1);
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentService.CreateStudent(student);
            TempData["Message"] = "Student Added Successfully!!";
            return RedirectToAction("Index", "Student");
        }
        [HttpGet]
        public ActionResult Edit(Guid StudentId)
        {
            Student student = _studentService.GetStudentById(StudentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Student student1 =  _studentService.UpdateStudent(student);
            TempData["Message"] = "Detail Updated Successfully!!";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid Id)
        {
            _studentService.DeleteStudent(Id);
            
              return RedirectToAction("Index");
         }
        
    }
}