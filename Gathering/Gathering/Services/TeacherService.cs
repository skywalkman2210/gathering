using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class TeacherService : Service
    {
#region RESTful Methods
        public List<Teacher> GetAll()
        {
            return this.GetAll<Teacher>();
        }

        public Teacher Get(int id)
        {
            return this.GetAll<Teacher>().First(t => t.Id == id);
        }

        public void Create(Teacher obj)
        {
            this.Create<Teacher>(obj);
        }

        public void Update(Teacher obj)
        {
            var newObj = this.db.Teachers.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Teacher obj)
        {
            this.Delete<Teacher>(obj);
        }
#endregion

#region Courses
        public List<Cours> GetTeacherCourses(int id)
        {
            return this.Get(id).TeachersHaveCourses.Select(t => t.Cours).ToList();
        }

        public void AddTeacherToCourse(Teacher teach, Cours obj)
        {
            teach.TeachersHaveCourses.Add(new TeachersHaveCours()
            {
                CourseId = obj.Id,
                TeacherId = teach.Id,
            });
            db.SaveChanges();
        }
#endregion
    }
}