using Gathering.Models;
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
        private TeacherService teacherService = new TeacherService();

        public ActionResult Index(int id)
        {
            ViewBag.Course = cService.Get(id);
            return View();
        }

        public ActionResult Add()
        {
            var model = new AddGradeViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddGradeViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.cService.Create(new Course()
                {
                    Name = model.Name,
                    Description = model.Description,
                });

                this.cService.SetCoursesSession();
                Course course = UserSession.Courses.FirstOrDefault(c => c.Name == model.Name && c.Description == model.Description);

                this.teacherService.AddCourse(course);

                return RedirectToAction(
                    course == null ? "Dashboard" : "Index",
                    course == null ? "Home" : "Grade",
                    course == null ? null : new { id = course.Id });
            }

            return View(model);
        }
    }
}