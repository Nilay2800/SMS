using SMS.Data;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
   public class StudentService
    {
        public readonly StudentProvider _studentProvider;
        //private string Firstname;

        public StudentService()
        {
            _studentProvider = new StudentProvider();
        }
        public Student GetStudentById(Guid StudentId)
        {
            var data = _studentProvider.GetStudentById(StudentId);
            Student students = new Student()
            {
                StudentId = data.StudentId,
                Firstname = data.Firstname,
                Lastname =  data.Lastname,
                 Age = data.Age,
                Gender = data.Gender,
                Standard = data.Standard,
                Email = data.Email,
                ContactNumber = data.ContactNumber

            };
            return students;
        }
        public Guid CreateStudent(Student student)
        {
            return _studentProvider.CreateStudent(student);
        }
        public Student UpdateStudent(Student student)
        {
            return _studentProvider.UpdateStudent(student);
        }
        public List<Student> GetallStudent()
        {
            var studentlist = _studentProvider.GetallStudent();
            return studentlist;
        }
        public void DeleteStudent(Guid StudentId)
        {
            _studentProvider.DeleteStudent(StudentId);
        }
     

    }
}
