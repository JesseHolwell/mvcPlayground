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
            //model = db.Surveys.ToList();
            List<Survey> model = new List<Survey>();
            model.Add(SurveyFactory.Generate());
            model.Add(SurveyFactory.Generate());
            model.Add(SurveyFactory.Generate());

            return View(model);
        }

        public ActionResult Create()
        {
            var survey = new Survey();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Survey survey)
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

        public ActionResult Survey(int id)
        {
            Survey model = db.Surveys.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
    }
}