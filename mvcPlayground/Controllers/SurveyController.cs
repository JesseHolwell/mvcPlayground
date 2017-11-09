using mvcPlayground.DAL;
using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class SurveyController : Controller
    {
        SurveyDBContext db = new SurveyDBContext();

        public ActionResult Index()
        {
            List<Survey> model = db.Surveys.ToList();

            return View(model);
        }

        // GET: Survey/View/5
        public ActionResult View(int? id)
        {
            Survey model;

            if (id != null && id > 0)
            {
                DBHelper.NormalizeSectionOrder(id.Value, db);
                model = db.Surveys.Find(id);
                if (model == null) return HttpNotFound();

            }
            else
            {
                model = new Survey() { Name = "New Survey" };
                db.Surveys.Add(model);
                db.SaveChanges();
            }

            return View(model);
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Surveys.Find(id);
            return View("Edit", model);
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int? id)
        {
            Survey model = db.Surveys.Find(id);
            db.Surveys.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Survey/AddSection/5
        public ActionResult AddSection(int id)
        {
            Survey model = db.Surveys.FirstOrDefault(x => x.Id == id);
            var max = 0;
            if (model.Sections != null && model.Sections.Count() > 0) max = model.Sections.Max(x => x.Order) + 1;

            model.Sections.Add(new Models.Section() { Name = "Placeholder", Order = max });

            db.SaveChanges();

            return RedirectToAction("View", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Survey survey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (survey.Id > 0)
                    {
                        var surveyToUpdate = db.Surveys.Find(survey.Id);
                        surveyToUpdate.Name = survey.Name;
                    }
                    else
                        db.Surveys.Add(survey);

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Edit", survey);
        }
    }
}

