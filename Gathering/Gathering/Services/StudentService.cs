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
            this.Create(obj);
        }

        public void Update(Student obj)
        {
            var newObj = this.db.Students.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Student obj)
        {
            this.Delete(obj);
        }
        #endregion

        #region Courses
        public List<Course> GetStudentCourses(int id)
        {
            var grades = this.Get(id).Grades;
            var courses = this.GetAll<Course>();

            var select = grades.Join(courses, 
                g => g.CourseId, 
                c => c.Id, (g, c) => new { Grade = g, Course = c }
            ).Where(c => c.Grade.StudentId == id);

            return select.Select(s => s.Course).ToList();
        }

        public List<Grade> GetStudentGrades(int id)
        {
            return this.Get(id).Grades.ToList();
        }
        #endregion
    }
}