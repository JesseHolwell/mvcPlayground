using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class SurveyController : Controller
    {
        SurveyDBContext db = new SurveyDBContext();

        public ActionResult Index()
        {
            List<SurveyModel> model = new List<SurveyModel>();
            model.Add(SurveyFactory.Generate());
            model.Add(SurveyFactory.Generate());
            model.Add(SurveyFactory.Generate());

            //model = db.Surveys.ToList();
            return View(model);
        }

        public ActionResult Survey(int id)
        {
            SurveyModel model = db.Surveys.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
    }
}