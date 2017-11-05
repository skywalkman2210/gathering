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
        public List<Course> GetAll()
        {
            return this.GetAll<Course>();
        }

        public Course Get(int id)
        {
            return this.GetAll<Course>().First(t => t.Id == id);
        }

        public void Create(Course obj)
        {
            this.Create(obj);
        }

        public void Update(Course obj)
        {
            var newObj = this.db.Courses1.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Course obj)
        {
            this.Delete(obj);
        }
        #endregion
    }
}