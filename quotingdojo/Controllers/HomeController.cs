using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotingDojo.Connectors;
using Microsoft.AspNetCore.Mvc;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx;

        public HomeController()
        {
            cnx = new DbConnector();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("addQuote")]
        public IActionResult addQuote(string quote, string author)
        {
            System.Console.WriteLine(quote);
            System.Console.WriteLine(author);
            string query = $"INSERT INTO quotes (quote, author) VALUES ('{quote}','{author}')";
            cnx.Execute(query);
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            var quotes = cnx.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.Quotes = quotes;
            return View();
        }
    }
}
