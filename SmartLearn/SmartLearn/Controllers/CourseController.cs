using SmartLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLearn.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var lstCourses = new List<CourseModel>
            {
                new CourseModel
                {
                    Id =1,
                    Title =".net",
                    Description = "test"
                },
                new CourseModel
                {
                    Id =2,
                    Title ="C#",
                    Description = "test2"
                }
            };
            return View(lstCourses);
        }
    }
}