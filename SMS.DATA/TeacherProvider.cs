using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class TeacherProvider:BaseProvider
    {
        public TeacherProvider()
        {

        }
        //public List<Teacher> GetAllTeacher()
        //{
        //    var teacher = _db.teachers.ToList();
        //    return teacher;
        //}
        public List<TeacherModel> GetAllTeacher()
        {
            return _db.teachers.Select(x => new TeacherModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                CreatedOn=x.CreatedOn,
                LastName = x.LastName,
                Email = x.Email,
                MobileNumber=x.MobileNumber,
            }).ToList();
        }
        public Teacher GetTeacherById(int id)
        {
            return _db.teachers.Find(id);
        }


        public Teacher CreateTeacher(TeacherModel teacherModel)
        {
            Teacher _teacher = new Teacher()
            {
                Id = teacherModel.Id,
                FirstName = teacherModel.FirstName,
                LastName = teacherModel.LastName,
                Email= teacherModel.Email,
                MobileNumber= teacherModel.MobileNumber,
                IsActive=teacherModel.IsActive,
                CreatedOn= teacherModel.CreatedOn
            };

            _db.teachers.Add(_teacher);
            _db.SaveChanges();

            return _teacher;
        }
        public TeacherModel UpdateTeacher(TeacherModel teacherModel)
        {
            var objtea = GetTeacherById(teacherModel.Id);
            objtea.FirstName = teacherModel.FirstName;
            objtea.LastName = teacherModel.LastName;
            objtea.Email = teacherModel.Email;
            objtea.MobileNumber = teacherModel.MobileNumber;
            objtea.IsActive = teacherModel.IsActive;
            objtea.CreatedOn = teacherModel.CreatedOn;

            _db.SaveChanges();
            return teacherModel;
        }
        public void DeleteTeacher(int Id)
        {
            var data = GetTeacherById(Id);
            if (data != null)
            {
                _db.teachers.Remove(data);
                _db.SaveChanges();
            }
        }



    }
}
