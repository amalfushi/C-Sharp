using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Factory;

namespace LostInTheWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory _trailFactory;
        public TrailController()
        {
            _trailFactory = new TrailFactory();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = _trailFactory.GetAllTrails();
            return View();
        }

        [HttpPost]
        [Route("CreateTrail")]
        public IActionResult CreateTrail(Trail trail)
        {
            if(ModelState.IsValid)
            {
                _trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }

        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult Trails(int id)
        {
            ViewBag.trail = _trailFactory.GetOneTrail(id);
            return View();
        }
    }
}
