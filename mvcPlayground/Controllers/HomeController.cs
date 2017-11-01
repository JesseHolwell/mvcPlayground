using mvcPlayground.DAL;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SurveyDBContext db = new SurveyDBContext();
            return View();
        }

        public ActionResult Teams()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}