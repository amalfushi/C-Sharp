using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Redirect("reviews");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Reviews.OrderByDescending(r => r.DateVisited).ToList();
            return View(AllReviews);
        }

        [HttpGet]
        [Route("addReview")]
        public IActionResult AddReview()
        {
            // Review nr = new Review();
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid){
                _context.Add(review);
                return Redirect("reviews");
            }
            return View("addReview");
        }
    }
}
