using mvcPlayground.DAL;
using mvcPlayground.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mvcPlayground.Controllers
{
    public class ImageController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Display inital page for user to upload a photo
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submit the photo, then redirect to results
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //TODO: convert HttpPostedFileBase into a octet stream

            var results = @"[{'faceRectangle':{
                'height': 89,
                'left': 95,
                'top': 54,
                'width': 89
            },
            'scores': {
                'anger': 7.96481145e-11,
                'contempt': 8.144482e-13,
                'disgust': 4.03720182e-11,
                'fear': 2.92296515e-13,
                'happiness': 1,
                'neutral': 1.95017071e-12,
                'sadness': 1.07769696e-13,
                'surprise': 7.470441e-11
            }]";

            //https://azure.microsoft.com/en-au/services/cognitive-services/computer-vision/

            EmotionsViewModel vm = new EmotionsViewModel(results);

            return View("Results", "Image", vm);
        }

        /// <summary>
        /// Display results to user
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public ActionResult Results(string results)
        {
            EmotionsViewModel vm = new EmotionsViewModel(results);
            RouteData.Values.Remove("Results");

            return View(vm);
        }
    }
}