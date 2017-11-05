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
            this.Create(obj);
        }

        public void Update(Teacher obj)
        {
            var newObj = this.db.Teachers.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Teacher obj)
        {
            this.Delete(obj);
        }
#endregion

#region Courses
        public List<Course> GetTeacherCourses(int id)
        {
            return this.Get(id).Courses.ToList();
        }

        public void AddCourse(Course obj)
        {
            this.Create(obj);
        }
#endregion
    }
}