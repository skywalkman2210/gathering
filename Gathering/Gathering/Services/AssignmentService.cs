using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class AssignmentService : Service
    {
        #region RESTful Methods
        public List<Assignment> GetAll()
        {
            return this.GetAll<Assignment>();
        }

        public Assignment Get(int id)
        {
            return this.GetAll<Assignment>().First(t => t.Id == id);
        }

        public void Create(Assignment obj)
        {
            this.Create<Assignment>(obj);
        }

        public void Update(Assignment obj)
        {
            var newObj = this.db.Assignments.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Assignment obj)
        {
            this.Delete<Assignment>(obj);
        }
        #endregion

        #region Other
        public void TeacherCreatesAssignment(Cours course, Assignment assignment)
        {
            assignment.CourseId = course.Id;
            this.Create<Assignment>(assignment);
        }
        #endregion
    }
}