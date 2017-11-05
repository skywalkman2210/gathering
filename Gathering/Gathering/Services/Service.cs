using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class Service
    {
        protected GatheringContext db = new GatheringContext();

        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return this.db.Set<TEntity>().ToList();
        }

        public void Create<TEntity>(TEntity obj) where TEntity : class
        {
            this.db.Set<TEntity>().Add(obj);
            this.db.SaveChanges();
        }

        public void Delete<TEntity>(TEntity obj) where TEntity : class
        {
            this.db.Set<TEntity>().Remove(obj);
            this.db.SaveChanges();
        }

        public List<Course> GetStudentCourses(int id)
        {
            var grades = this.GetAll<Student>().First(s => s.Id == id).Grades;
            var courses = this.GetAll<Course>();

            var select = grades.Join(courses,
                g => g.CourseId,
                c => c.Id, (g, c) => new { Grade = g, Course = c }
            ).Where(c => c.Grade.StudentId == id);

            return select.Select(s => s.Course).ToList();
        }
    }
}