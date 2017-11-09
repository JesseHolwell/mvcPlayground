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
            //List<Section> model = db.Sections.Where(x=>x.SurveyId == id).ToList();
            Section model = db.Sections.FirstOrDefault(x => x.Id == id);

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
        public ActionResult Edit(int id)
        {
            var model = db.Sections.Find(id);
            return View("Edit", model);
        }

        public ActionResult AddQuestion(int id)
        {
            Section model = db.Sections.FirstOrDefault(x => x.Id == id);
            var max = 0;
            if (model.Questions != null && model.Questions.Count() > 0) max = model.Questions.Max(x => x.Order) + 1;

            model.Questions.Add(new Models.Question() { Text = "Placeholder", Order = max });

            db.SaveChanges();

            return RedirectToAction("Index", "Section", new { id = id });
        }

        public ActionResult MoveUp(int id)
        {
            var model = db.Sections.FirstOrDefault(x => x.Id == id);

            DBHelper.NormalizeSectionOrder(model.SurveyId, db);
            Move(model.Id, false);

            return RedirectToAction("View", "Survey", new { id = model.SurveyId } );
        }

        public ActionResult MoveDown(int id)
        {
            var model = db.Sections.FirstOrDefault(x => x.Id == id);

            DBHelper.NormalizeSectionOrder(model.SurveyId, db);
            model = Move(model.Id, true);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Section section)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (section.Id > 0)
                    {
                        var sectionToUpdate = db.Sections.Find(section.Id);
                        sectionToUpdate.Name = section.Name;
                    }
                    else
                        db.Sections.Add(section);

                    db.SaveChanges();
                    return RedirectToAction("View", "Survey", new { id = section.SurveyId });
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Edit", section);
        }

        public ActionResult Delete(int? id)
        {
            Section model = db.Sections.Find(id);
            db.Sections.Remove(model);
            db.SaveChanges();
            return RedirectToAction("View", "Survey", new { id = model.SurveyId });
        }
    }
}