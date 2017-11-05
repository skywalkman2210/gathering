using Gathering.Models;
using Gathering.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gathering.Controllers
{
    public class HomeController : Controller
    {
        private CourseService cService = new CourseService();

        public HomeController()
        {
            this.cService.SetCoursesSession();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.Courses = UserSession.Courses; 
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}