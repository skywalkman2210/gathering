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

        public static IEnumerable<Course> Courses
        {
            get
            {
                return HttpContext.Current.Session["Courses"] == null
                    ? new List<Course>().AsEnumerable()
                    : HttpContext.Current.Session["Courses"] as IEnumerable<Course>;
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
    }
}