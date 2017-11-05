using Gathering.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gathering.Controllers
{
    public class GradeController : Controller
    {
        private CourseService cService = new CourseService();

        public ActionResult Index(int id)
        {
            ViewBag.Course = cService.Get(id);
            return View();
        }
    }
}