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
        private AssignmentService assignmentService = new AssignmentService();

        public GradeController()
        {
            cService.SetCoursesSession();
        }

        public ActionResult Index(int id)
        {
            var teacher = teacherService.GetAll().First(t => t.UserId == UserSession.User.Id);
            var assignments = assignmentService.GetAll().Where(a => a.CourseId == id);

            ViewBag.Course = cService.Get(id);
            ViewBag.Teacher = teacher;
            ViewBag.Assignments = assignments;
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
                this.cService.Create(new Cours()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CourseNumber = model.CourseNumber,
                });

                Cours course = this.cService.GetAll().FirstOrDefault(c => c.Name == model.Name && c.Description == model.Description && c.CourseNumber == model.CourseNumber);
                var teacher = this.teacherService.GetAll().First(t => t.UserId == UserSession.User.Id);
                this.teacherService.AddTeacherToCourse(teacher, course);

                this.cService.SetCoursesSession();

                return RedirectToAction(
                    course == null ? "Dashboard" : "Index",
                    course == null ? "Home" : "Grade",
                    course == null ? null : new { id = course.Id });
            }

            return View(model);
        }
    }
}