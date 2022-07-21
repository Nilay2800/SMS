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
    public class StudentController : BaseController
    {
        public readonly StudentService _studentService;
       
        
        public StudentController()
        {
            _studentService = new StudentService();
            
            
        }
        public ActionResult Index( Guid? studentId)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Student.ToString(), AcessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            ViewBag.Permission = GetPermission(AuthorizeFormAccess.FormAccessCode.Student.ToString());
            List<StudentModel> studentlist = _studentService.GetallStudent().ToList();
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
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Student.ToString(), AcessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            StudentModel s1 = new StudentModel();
            return View(s1);
        }
        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            _studentService.CreateStudent(student);
            TempData["Message"] = "Student Added Successfully!!";
            return RedirectToAction("Index", "Student");
        }
        [HttpGet]
        public ActionResult Edit(Guid StudentId)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Student.ToString(), AcessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            StudentModel student = _studentService.GetStudentById(StudentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            StudentModel student1 =  _studentService.UpdateStudent(student);
            TempData["Message"] = "Detail Updated Successfully!!";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid Id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.Student.ToString(), AcessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            _studentService.DeleteStudent(Id);
            
              return RedirectToAction("Index");
         }
        
    }
}