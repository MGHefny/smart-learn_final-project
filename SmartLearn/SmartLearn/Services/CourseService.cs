using SmartLearn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLearn.Services
{
    public interface ICourseService
    {
        // Courses Service
        int Create(Course course);
        int Update(Course updatedCourse);
        List<Course> ReadAll();

        Course Get(int Id);
    }
    public class CourseService : ICourseService
    {
        private readonly Courses_DBEntities db;
        public CourseService()
        {
            db = new Courses_DBEntities();
        }
        public int Create(Course course)
        {
            course.Creation_Date = DateTime.Now;
            db.Courses.Add(course);
            return db.SaveChanges();
        }

        public Course Get(int Id)
        {
            return db.Courses.Find(Id);
        }

        public List<Course> ReadAll()
        {
            return db.Courses.ToList();
        }

        public int Update(Course updatedCourse)
        {
            db.Courses.Attach(updatedCourse);
            db.Entry(updatedCourse).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}