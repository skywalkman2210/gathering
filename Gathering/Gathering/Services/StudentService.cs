using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class StudentService : Service
    {
        #region RESTful Methods
        public List<Student> GetAll()
        {
            return this.GetAll<Student>();
        }

        public Student Get(int id)
        {
            return this.GetAll<Student>().First(t => t.Id == id);
        }

        public void Create(Student obj)
        {
            this.Create<Student>(obj);
        }

        public void Update(Student obj)
        {
            var newObj = this.db.Students.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Student obj)
        {
            this.Delete<Student>(obj);
        }
        #endregion

        #region Courses
        

        public List<Grade> GetStudentGrades(int id)
        {
            return this.Get(id).Grades.ToList();
        }
        #endregion
    }
}