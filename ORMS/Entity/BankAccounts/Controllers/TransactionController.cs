using System;
using System.Linq;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class TransactionController : Controller
    {
        private BankAccountContext _context;
        public TransactionController(BankAccountContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("account/{id}")]
        public IActionResult Account(int id)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null){
                return Redirect("/");
            }
            if(id != LogId){
                return Redirect($"/account/{LogId}");
            }
            // System.Console.WriteLine(_context.Users.Where(b => b.UserId == LogId));
            User user = _context.Users.Include(u => u.Transactions).Where(u => u.UserId == LogId).SingleOrDefault();

            if(user.Transactions != null)
            {
                user.Transactions = user.Transactions.OrderByDescending(t => t.CreatedAt).ToList();
            }
            ViewBag.User = user;
            // if((bool)TempData["InsufficientFunds"] == true)
            // {
            //     ViewBag.InsufficientFunds = true;
            // }
            return View();
        }

        [HttpPost]
        [Route("CreateTransaction")]
        public IActionResult CreateTransaction(int amount)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null)
            {
                return Redirect("/");
            }
            User user = _context.Users.Where(u => u.UserId == LogId).SingleOrDefault();

            if(amount < 0 && user.Balance+amount < 0 ){
                TempData["Error"] = "Insufficient Funds";
            }
            else
            {
                Transaction nt = new Transaction{
                    Amount = amount,
                    User = user,
                    CreatedAt = DateTime.Now,
                };
                user.Balance += amount;
                _context.Transactions.Add(nt);
                _context.SaveChanges();
            }
            return Redirect($"account/{LogId}");
        }
    }
}