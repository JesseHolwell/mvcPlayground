using mvcPlayground.DAL;
using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class SectionController : Controller
    {
        SurveyDBContext db = new SurveyDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //var section = new Section();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Section section)
        {
            //if (selectedCourses != null)
            //{
            //    instructor.Courses = new List<Course>();
            //    foreach (var course in selectedCourses)
            //    {
            //        var courseToAdd = db.Courses.Find(int.Parse(course));
            //        instructor.Courses.Add(courseToAdd);
            //    }
            //}
            //if (ModelState.IsValid)
            //{
            //    db.Instructors.Add(instructor);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //PopulateAssignedCourseData(instructor);
            return View();
        }

        public ActionResult Section(int id)
        {
            Section model = db.Sections.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
    }
}