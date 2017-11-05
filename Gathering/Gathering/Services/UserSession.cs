using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gathering.Models;

namespace Gathering.Services
{
    public static class UserSession
    {
        public static AspNetUser User
        {
            get
            {
                return HttpContext.Current.Session["User"] == null 
                    ? new AspNetUser()
                    : HttpContext.Current.Session["User"] as AspNetUser;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static IEnumerable<Cours> Courses
        {
            get
            {
                var Cours = HttpContext.Current.Session["Courses"] == null
                    ? new List<Cours>().AsEnumerable()
                    : HttpContext.Current.Session["Courses"] as IEnumerable<Cours>;
                return Cours;
            }
            set
            {
                HttpContext.Current.Session["Courses"] = value;
            }
        }

        public static RoleType RoleType
        {
            get
            {
                return HttpContext.Current.Session["RoleType"] == null
                    ? RoleType.Admin
                    : (RoleType)Convert.ToInt32(HttpContext.Current.Session["RoleType"]);
            }
            set
            {
                HttpContext.Current.Session["RoleType"] = value;
            }
        }

        public static Cours CurrentCourse
        {
            get
            {
                return HttpContext.Current.Session["Courses"] == null
                    ? new Cours()
                    : HttpContext.Current.Session["Courses"] as Cours;
            }
            set
            {
                HttpContext.Current.Session["Courses"] = value;
            }
        }
    }
}