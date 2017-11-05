using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Services
{
    public class GradeService : Service
    {
        #region RESTful Methods
        public List<Grade> GetAll()
        {
            return this.GetAll<Grade>();
        }

        public Grade Get(int id)
        {
            return this.GetAll<Grade>().First(t => t.Id == id);
        }

        public void Create(Grade obj)
        {
            this.Create<Grade>(obj);
        }

        public void Update(Grade obj)
        {
            var newObj = this.db.Grades.First(t => t.Id == obj.Id);
            newObj = obj;
            this.db.SaveChanges();
        }

        public void Delete(Grade obj)
        {
            this.Delete<Grade>(obj);
        }
        #endregion

        #region Other
        #endregion
    }
}