using Gathering.Models;
using Gathering.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gathering.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentService assignmentService = new AssignmentService();
        private CourseService courseService = new CourseService();
        private GradeService gradeService = new GradeService();
        private StudentService studentService = new StudentService();
        private TeacherService teacherService = new TeacherService();

        public ActionResult Index(int id)
        {
            ViewBag.Assignment = assignmentService.GetAll().First(a => a.Id == id);
            return View();
        }

        public ActionResult Create(int courseId, int teacherId)
        {
            var model = new AssignmentCreateViewModel()
            {
                CourseId = courseId,
                TeacherId = teacherId,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AssignmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Create(new Assignment()
                {
                    Description = model.Description,
                    DueDate = model.DueDate,
                    PointsEarned = model.PointsTotal,
                    PointsTotal = model.PointsPossible,
                    CourseId = model.CourseId,
                    TeacherId = model.TeacherId,
                });

                var assignment = assignmentService.GetAll().First(a => a.Description == model.Description && a.DueDate == a.DueDate);
                
                return RedirectToAction("Index", "Assignment", new { id = assignment.Id });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var assignment = assignmentService.Get(id);
            var courseId = assignment.CourseId;

            assignmentService.Delete(assignment);
            return RedirectToAction("Index", "Grade", new { id = courseId });
        }
    }
}