using Gathering.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gathering.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private TeacherService tService = new TeacherService();
        private StudentService sService = new StudentService();
        private CourseService cService = new CourseService();

        public ActionResult Index()
        {
            ViewBag.AllCourses = true;
            ViewBag.Courses = cService.GetAll();
            return View();
        }

        // GET: Course
        public ActionResult Index(int id)
        {
            ViewBag.AllCourses = false;
            ViewBag.Course = cService.Get(id);
            return View();
        }
    }
}