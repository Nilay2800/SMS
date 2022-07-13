using SMS.Data;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class TeacherService
    {
        public readonly TeacherProvider teacherProvider;
        public TeacherService()
        {
            teacherProvider = new TeacherProvider();
        }
        public List<Teacher> GetAllTeacher()
        {
            var teachers = teacherProvider.GetAllTeacher();
            return teachers;
        }
        public int CreateTeacher(Teacher teachers)
        {         
            return teacherProvider.CreateTeacher(teachers);
        }
        public Teacher UpdateTeacher(Teacher teacherModel)
        {
            return teacherProvider.UpdateTeacher(teacherModel);
        }
        public Teacher GetTeacherById(int id)
        {
            var data = teacherProvider.GetTeacherById(id);
            Teacher teacherModel = new Teacher()
            {
                Id = data.Id,
                IsActive = data.IsActive,
                FirstName=data.FirstName,
                LastName=data.LastName,
                Email=data.Email,
                MobileNumber=data.MobileNumber,
                CreatedOn=data.CreatedOn
                
            };
            return teacherModel;
        }
        public void DeleteTeacher(int Id)
        {
            teacherProvider.DeleteTeacher(Id);
        }
    }
}
