using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class Survey : Controller{
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.errors = new string[0];
            return View();
        }

        [Route("submit")]
        [HttpPost]
        public IActionResult Submit(string name, string location, string language, string comment)
        {
            if(name != null)
            {
                ViewBag.name = name;
                ViewBag.location = location;
                ViewBag.language = language;
                ViewBag.comment = comment;
                return View("Results");
            }
            ViewBag.errors = new string[]{"Names are required."};
            return View("Index");

            
        }
    }
}