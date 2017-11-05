using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class CourseService : Service
    {
        #region RESTful Methods
        public List<Cours> GetAll()
        {
            return this.GetAll<Cours>();
        }

        public Cours Get(int id)
        {
            return this.GetAll<Cours>().First(t => t.Id == id);
        }

        public void Create(Cours obj)
        {
            this.Create<Cours>(obj);
        }

        public void Update(Cours obj)
        {
            var newObj = this.db.Courses.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Cours obj)
        {
            this.Delete<Cours>(obj);
        }
        #endregion

        #region Other

        public void SetCoursesSession()
        {
            switch (UserSession.RoleType)
            {
                case RoleType.Teacher:
                    var teacher = GetAll<Teacher>().First(s => s.AspNetUser.UserName == UserSession.User.Email);
                    UserSession.Courses = teacher.TeachersHaveCourses.Select(thc => thc.Cours);
                    break;
                case RoleType.Student:
                    var student = GetAll<Student>().First(s => s.AspNetUser.UserName == UserSession.User.Email);
                    UserSession.Courses = this.GetStudentCourses(student.Id);
                    break;
                default:
                    break;
            }
        }
#endregion
    }
}