using mvcPlayground.DAL;
using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class SectionController : Controller
    {
        SurveyDBContext db = new SurveyDBContext();

        public ActionResult Index(int id)
        {
            List<Section> model = db.Sections.Where(x=>x.SurveyId == id).ToList();

            return View(model);
        }

        // GET: Section/View/5
        public ActionResult View(int? id)
        {
            Section model;

            if (id != null && id > 0)
            {
                model = db.Sections.Find(id);
                if (model == null) return HttpNotFound();
            }
            else
                model = new Section();

            return View(model);
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int Id)
        {
            var model = db.Sections.Find(Id);
            return View("Edit", model);
        }

        public void AddQuestion(int id)
        {
            Section model = db.Sections.FirstOrDefault(x => x.Id == id);
            model.Questions.Add(new Models.Question());

            //return View("View", model);
            RedirectToAction("View", "Survey", model.SurveyId);
        }

        public ActionResult MoveUp(int id)
        {
            var model = db.Sections.FirstOrDefault(x => x.Id == id);

            NormalizeSectionOrder(model.SurveyId);
            Move(model.Id, false);

            //var survey = db.Surveys.FirstOrDefault(x => x.Id == model.SurveyId);
            //return View("../Survey/View", survey);

            return RedirectToAction("View", "Survey", new { id = model.SurveyId } );
        }

        public ActionResult MoveDown(int id)
        {
            var model = db.Sections.FirstOrDefault(x => x.Id == id);

            NormalizeSectionOrder(model.SurveyId);
            model = Move(model.Id, true);

            //var survey = db.Surveys.FirstOrDefault(x => x.Id == model.SurveyId);
            //return View("../Survey/View", survey);

            return RedirectToAction("View", "Survey", new { id = model.SurveyId });
        }

        public Section Move(int id, bool moveUp)
        {
            var amount = -1;
            if (moveUp)
                amount = 1;

            Section model = db.Sections.FirstOrDefault(x => x.Id == id);

            try
            {
                var sections = db.Sections.Where(x => x.SurveyId == model.SurveyId).OrderBy(x => x.Order).ToList();
                var replace = sections.FirstOrDefault(x => x.Order == model.Order + amount);
                replace.Order -= amount;
                model.Order += amount;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return model;
        }

        public void NormalizeSectionOrder(int surveyId)
        {
            var sections = db.Sections.Where(x => x.SurveyId == surveyId).OrderBy(x => x.Order).ToList();
            LinkedList<Section> list2 = new LinkedList<Section>();

            list2.AddFirst(sections[0]);
            for (var i = 1; i < sections.Count(); i++)
                list2.AddLast(sections[i]);

            var counter = 0;
            foreach (var v in list2)
                v.Order = counter++;

            db.SaveChanges();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Section model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        var sectionToUpdate = db.Sections.Find(model.Id);
                        sectionToUpdate.Name = model.Name;
                    }
                    else
                        db.Sections.Add(model);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Edit", model);
        }
    }
}