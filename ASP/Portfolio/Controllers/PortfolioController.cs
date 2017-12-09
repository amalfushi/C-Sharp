using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Controllers
{
    public class Portfolio : Controller
    {
        private Dictionary<string,string>[] projects;
        // public Portfolio() => projects = new Dictionary<string, string> { }();

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("home");
        }

        [Route("home")]
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [Route("projects")]
        [HttpGet]
        public IActionResult Projects()
        {
            // Dictionary<string, string> p1 = new Dictionary<string, string>();
            // p1.Add("title", "What is love?");
            // p1.Add("description", "Baby don't hurt me, don't hurt me, no more");
            
            return View();
        }

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}