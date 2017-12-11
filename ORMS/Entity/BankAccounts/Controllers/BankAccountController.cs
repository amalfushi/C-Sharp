using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    
    public class BankAccountController : Controller
    {
        private BankAccountContext _context;
        public BankAccountController(BankAccountContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(RegisterUser u)
        {
            if(ModelState.IsValid){
                List<User> users = _context.Users.Where(nu => nu.Email == u.Email).ToList();
                if(users.Count > 0){
                    ViewBag.InvalidEmail = true;
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User nUser = new User();
                nUser.Password = Hasher.HashPassword(nUser, u.Password);
                nUser.FirstName = u.FirstName;
                nUser.LastName = u.LastName;
                nUser.Email = u.Email;
                nUser.Balance = 0;
                _context.Add(nUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", nUser.UserId);
                System.Console.WriteLine("***********  Success");
                return View("Index");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUser lu)
        {
            if(ModelState.IsValid)
            {
                User user = _context.Users.Where(u => u.Email == lu.LogEmail).SingleOrDefault();
                if(user != null)
                {
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    // System.Console.WriteLine(lu.LogPassword + " ***********************");
                    // System.Console.WriteLine(hasher.HashPassword(lu, lu.LogPassword)+ " *****************");
                    // System.Console.WriteLine(user.Password + " ***********************");
                    if(hasher.VerifyHashedPassword(user, user.Password, lu.LogPassword) != 0)
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        return Redirect($"/account/{user.UserId}");
                    }
                }
                ViewBag.InvalidLogin = true;
                return View ("Index");
            }
            System.Console.WriteLine("*********   Ya done goofed");
            return View("Index");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}