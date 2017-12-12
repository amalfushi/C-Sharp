using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class DashboardController : Controller
    {
        private WeddingPlannerContext _context;

        public DashboardController(WeddingPlannerContext context)
        {
            _context = context;
        }

//Dashboard with all weddings****************************************************************************************************/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null){
                return Redirect("/");
            }
            ViewBag.UserId =  LogId;
            List<Wedding> weddings = _context.Weddings.Include(wd => wd.Attendees).OrderBy(wd => wd.Date).ToList();
            if(weddings.Count < 1){
                weddings = new List<Wedding>();
            }
            ViewBag.Weddings = weddings;
            //list of all the weddings that the logged user is attending
            List<RSVP> UserAttending = _context.RSVPs.Where(wa => wa.UserId == LogId).ToList();
            //list of all the guest
            List<int> weddingsAttending = new List<int>();
            // for each wedding that the user is attending, stick that wedding id in it's own list and use it for the Action links on the Dashboard
            foreach (RSVP wa in UserAttending)
            {
                weddingsAttending.Add(wa.WeddingId);
            }
            ViewBag.Attending = weddingsAttending;
            return View("../WeddingPlanner/Dashboard");
        }

//New Wedding View****************************************************************************************************/
        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null){
                return Redirect("/");
            }
            return View("../WeddingPlanner/NewWedding");
        }

//Create Wedding****************************************************************************************************/
        [HttpPost]
        [Route("CreateWedding")]
        public IActionResult CreateWedding(CreWedding nW)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null){
                return Redirect("/");
            }
            if(ModelState.IsValid){
                if(nW.Date < DateTime.Now)
                {
                    ViewBag.InvalidDate = true;
                    return View("../WeddingPlanner/NewWedding");
                }
                else
                {
                    User user = _context.Users.Where(u => u.UserId == LogId).FirstOrDefault();
        
                    Wedding wedding = new Wedding{
                        Wedder1 = nW.Wedder1,
                        Wedder2 = nW.Wedder2,
                        Date = nW.Date,
                        Address = nW.Address,
                        CreatorId = user.UserId
                    };
                    _context.Weddings.Add(wedding);
                    _context.SaveChanges();
                }
            }
            return Redirect("/dashboard");
        }

        [HttpGet]
        [Route("delete/{weddingId}")]
        public IActionResult Delete(int weddingId)
        {
            Wedding remove = _context.Weddings.Where(wd => wd.WeddingId == weddingId).FirstOrDefault();
           _context.Weddings.Remove(remove);
           _context.SaveChanges();
           return Redirect("/dashboard");
        }

//RSVP to a wedding****************************************************************************************************/
        [HttpGet]
        [Route("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null){
                return Redirect("/");
            }
            User user = _context.Users.Where(u => u.UserId == LogId).SingleOrDefault();
            Wedding wedding = _context.Weddings.Where(w => w.WeddingId == weddingId).SingleOrDefault();

            RSVP nwa = new RSVP();
            nwa.User = user;
            nwa.Wedding = wedding;
            _context.RSVPs.Add(nwa);
            _context.SaveChanges();
            return Redirect("/dashboard");
        }

//Un-RSVP to a wedding****************************************************************************************************/
        [HttpGet]
        [Route("unrsvp/{weddingId}")]
        public IActionResult UNRSVP(int weddingId)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null)
            {
                return Redirect("/");
            }
            User user = _context.Users.Where(u => u.UserId == LogId).SingleOrDefault();
            RSVP rwa = _context.RSVPs.Where(wa => wa.WeddingId == weddingId && wa.UserId == LogId).SingleOrDefault();

            _context.RSVPs.Remove(rwa);
            _context.SaveChanges();
            return Redirect("/dashboard");
        }

//View a wedding and all it's guests****************************************************************************************************/
        [HttpGet]
        [Route("view/{weddingId}")]
        public IActionResult View(int weddingId)
        {
            int? LogId = HttpContext.Session.GetInt32("UserId");
            if(LogId == null )
            {
                return Redirect("/");
            }

            User user = _context.Users.Where(u => u.UserId == LogId).SingleOrDefault();

            Wedding wedding = _context.Weddings.Where(wd => wd.WeddingId == weddingId).SingleOrDefault();

            List<RSVP> Attendees = _context.RSVPs.Where(g => g.WeddingId == weddingId).Include(g => g.User).ToList();

            List<User> guests = new List<User>();
            foreach(RSVP wd in Attendees)
            {
                guests.Add(wd.User);
            }

            ViewBag.User = user;
            ViewBag.Wedding = wedding;
            ViewBag.Guests = guests;
            return View("../WeddingPlanner/Wedding");
        }
    }
}