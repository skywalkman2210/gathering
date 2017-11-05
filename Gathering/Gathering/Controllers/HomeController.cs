﻿using Gathering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gathering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.Courses = Session["Courses"] as IEnumerable<Course> == null
                ? new List<Course>()
                : Session["Courses"] as IEnumerable<Course>; ;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}