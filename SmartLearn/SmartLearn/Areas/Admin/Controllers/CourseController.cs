using AutoMapper;
using SmartLearn.Data;
using SmartLearn.Models;
using SmartLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLearn.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper mapper;
        private readonly CourseService courseService;
        private readonly CategoryService categoryService;
        private readonly TrainerService trainerService;

        public CourseController()
        {
            mapper = AutoMapperConfig.Mapper;
            courseService = new CourseService();
            categoryService = new CategoryService();
            trainerService = new TrainerService();
        }
        // GET: Admin/Course
        public ActionResult Index()
        {
            var coursesList = courseService.ReadAll();
            var mappedCoursesList = mapper.Map<List<CourseModel>>(coursesList);
            return View(mappedCoursesList);
        }

        public ActionResult Create()
        {
            var courseModel = new CourseModel();
            InitSelectList(ref courseModel);
            return View(courseModel);
        }

        [HttpPost]
        public ActionResult Create(CourseModel courseData)
        {
            InitSelectList(ref courseData);
            try
            {
                if (ModelState.IsValid)
                {
                    var courseDTO = mapper.Map<Course>(courseData);
                    courseDTO.Category = null;
                    courseDTO.Trainer = null;
                    int result = courseService.Create(courseDTO);

                    if(result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An Error Occurred!!";
                }
                return View(courseData);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(courseData);
            }
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
                return HttpNotFound();

            var currentCourseData = courseService.Get(Id.Value);
            var courseModel = mapper.Map<CourseModel>(currentCourseData);

            InitSelectList(ref courseModel);
            return View(courseModel);
        }

        [HttpPost]
        public ActionResult Edit(CourseModel courseData)
        {
            InitSelectList(ref courseData);
            try
            {
                if (ModelState.IsValid)
                {
                    var courseDTO = mapper.Map<Course>(courseData);
                    courseDTO.Category = null;
                    courseDTO.Trainer = null;
                    int result = courseService.Update(courseDTO);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An Error Occurred!!";
                }
                return View(courseData);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(courseData);
            }
        }

        private void InitSelectList(ref CourseModel courseModel)
        {
            var categories = categoryService.ReadAll();
            var mappedCategoriesList = mapper.Map<IEnumerable<CategoryModel>>(categories);
            courseModel.Categories = new SelectList(mappedCategoriesList, "Id", "Name");

            var trainers = trainerService.ReadAll();
            var mappedTrainersList = mapper.Map<IEnumerable<TrainerModel>>(trainers);
            courseModel.Trainers = new SelectList(mappedTrainersList, "Id", "Name");
        }
    }
}