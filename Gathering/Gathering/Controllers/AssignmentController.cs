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

        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new AssignmentCreateViewModel();
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
                    GradeId = model.GradeId,
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
            var gradeId = assignment.GradeId;

            assignmentService.Delete(assignment);
            return RedirectToAction("Index", "Grade", new { id = gradeId });
        }
    }
}