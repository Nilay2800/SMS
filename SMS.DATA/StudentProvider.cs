using com.sun.tools.doclets.formats.html.resources;
using Nest;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class StudentProvider : BaseProvider
    {


        public StudentProvider()
        {

        }

        public Student GetStudentById(Guid StudentId)
        {
            return _db.students.Find(StudentId);
        }
        public Guid CreateStudent(Student students)
        {
            var createdby = (from Student in _db.students
                             where students.Email == SessionHelper.Email
                             select students.StudentId).FirstOrDefault();

            Student obj = new Student()
            {
                StudentId = Guid.NewGuid(),
                Firstname = students.Firstname,
                Lastname = students.Lastname,
                Age = students.Age,
                Gender = students.Gender,
                Standard = students.Standard,
                Email = students.Email,
                ContactNumber = students.ContactNumber

            };
            _db.students.Add(obj);
            _db.SaveChanges();
            return students.StudentId;
        }
        public Student UpdateStudent(Student students)
        {
            Student obj  = new Student();
            var obj1 = GetStudentById(students.StudentId);
            obj1.StudentId = students.StudentId;
            obj1.Firstname = students.Firstname;
            obj1.Lastname = students.Lastname;
            obj1.Age = students.Age;
            obj1.Gender = students.Gender;
            obj1.Standard = students.Standard;
            obj1.Email = students.Email;
            obj1.ContactNumber = students.ContactNumber;
            _db.SaveChanges();
            return students;
        }
        public List<Student> GetallStudent()
        {
            var studentlist = (from Student in _db.students
                               select new Student
                               {
                                   StudentId = Student.StudentId,
                                   Firstname = Student.Firstname,
                                   Lastname = Student.Lastname,
                                   Age = Student.Age,
                                   Gender = Student.Gender,
                                   Standard = Student.Standard,
                                   Email = Student.Email,
                                   ContactNumber = Student.ContactNumber
                               }).OrderBy(a => a.StudentId).ToList();
            return studentlist.ToList();
        }

        public Student DeleteStudent(Guid StudentId)
        {
            var data = GetStudentById(StudentId);
            if (data != null)
            {
                _db.students.Remove(data);
                _db.SaveChanges();
            }
            return data;
        }


    }
}

