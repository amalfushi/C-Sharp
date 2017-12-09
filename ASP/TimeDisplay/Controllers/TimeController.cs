using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
// using JsonData;

namespace TimeDisplay.Controllers
{
    public class TimeController : Controller
    {
        public TimeController()
        {

        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}