using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginReg.Connectors;
using LoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        DbConnector cnx = new DbConnector();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            // System.Console.WriteLine("***************************");
            if(ModelState.IsValid)
            {
                List<Dictionary<string, object>> users = cnx.Query($"SELECT id FROM users WHERE email = '{user.Email}'");
                if (users.Count > 0)
                {
                    ViewBag.EmailError = "Email Already in use.";
                    return View("Index");
                }
                string query = $"INSERT INTO users (first_name, last_name, email, password) VALUES ('{user.First_Name}', '{user.Last_Name}', '{user.Email}', '{user.Password}'); SELECT LAST_INSERT_ID() as id";
                HttpContext.Session.SetInt32("id", Convert.ToInt32(cnx.Query(query)[0]["id"]));
                // cnx.Execute(query);
                return View("Contact");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                List<Dictionary<string, object>> users = cnx.Query($"SELECT id,password FROM users WHERE email = '{user.Email}'");
                if (users.Count < 1 || user.Password != (string)users[0]["password"]){
                    ViewBag.LoginError = "Invalid Email or Password";
                    return View("Index");
                }
                return RedirectToAction("Contact");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
