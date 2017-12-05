using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DojoDachi.Controllers
{
    public class Dachi : Controller
    {
        Random rand = new Random();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.DojoDachi = GetDachi();
            ViewBag.Message = "You've got a brand new Dachi!";
            ViewBag.Reaction = "";
            ViewBag.Status = "running";
            return View();
        }

        public DojoDachi GetDachi()
        {
            if(HttpContext.Session.GetObjectFromJson<DojoDachi>("DojoDachi") == null)
            {
                SetDachi(new DojoDachi());
            }
            DojoDachi editDachi = HttpContext.Session.GetObjectFromJson<DojoDachi>("DojoDachi");
            return editDachi;
        }

        public void SetDachi(DojoDachi dachi)
        {
            HttpContext.Session.SetObjectAsJson("DojoDachi", dachi);
            ViewBag.DojoDachi = dachi;
            ViewBag.Status = "running";
            CheckForDeath(dachi);
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed()
        {
            DojoDachi editDachi = GetDachi();
            if(editDachi.Meals > 0)
            {
                editDachi.Meals --;
                if(rand.Next(0,4) > 0)
                {
                    editDachi.Fullness += rand.Next(5,11);
                    ViewBag.Reaction = ":)";
                    ViewBag.Message = "Your Dachi Enjoyed that meal!";
                }
                else
                {
                    ViewBag.Reaction = ":(";
                    ViewBag.Message = "Your Dachi didn't like that meal very much...";
                }
            }
            else
            {
                ViewBag.Reaction = ":(";
                ViewBag.Message = "You Don't have any food for your Dachi.";
            }
            SetDachi(editDachi);
            return View("Index");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play()
        {
            DojoDachi editDachi = GetDachi();
            if(editDachi.Energy > 4)
            {
                editDachi.Energy --;
                if(rand.Next(0,4) > 0)
                {
                    editDachi.Happiness += rand.Next(5, 11);
                    ViewBag.Reaction = ":)";
                    ViewBag.Message = "Your Dachi had fun playing!";
                }
                else
                {
                    ViewBag.Reaction = ":(";
                    ViewBag.Message = "Your Dachi didn't want to play...";
                }
            }
            else
            {
                ViewBag.Reaction = ":(";
                ViewBag.Message = "You Don't have enough energy.";
            }
            SetDachi(editDachi);
            return View("Index");
        }

        [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            DojoDachi editDachi = GetDachi();
            if(editDachi.Energy > 4)
            {
                editDachi.Energy -=5;
                editDachi.Meals += rand.Next(1, 4);
                ViewBag.Reaction =":)";
                ViewBag.Message = "You worked hard to feed your Dachi";
            }
            else
            {
                ViewBag.Reaction = ":(";
                ViewBag.Message = "Not enough energy.";
            }
            SetDachi(editDachi);
            return View("Index");
        }

        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            DojoDachi editDachi = GetDachi();
            editDachi.Energy += 15;
            editDachi.Fullness -=5;
            editDachi.Happiness -=5;
            ViewBag.Reaction = ":)";
            ViewBag.Message = "Your Dachi seems well rested";
            SetDachi(editDachi);
            return View("Index");
        }

        public void CheckForDeath(DojoDachi editDachi)
        {
            if(editDachi.Fullness < 1 || editDachi.Happiness < 1)
            {
                ViewBag.Reaction = "X(";
                ViewBag.Message = "Oh no! Your Dachi has Died...";
                ViewBag.Status = "over";
            }
            else if(editDachi.Fullness > 99 && editDachi.Happiness > 99)
            {
                ViewBag.Reaction = ":D";
                ViewBag.Message = "Congratulations! You Win!";
                ViewBag.Status = "over";
            }
        }

        // [HttpPost]
        // [Route("performAction")]
        // public IActionResult PerformAction(string action)
        // {
        //     DojoDachi editDachi = GetDachi();

        //     ViewBag.Status = "running";
        //     switch(action)
        //     {
        //         case "feed":
        //             if(editDachi.Meals > 0)
        //             {
        //                 editDachi.Meals --;
        //                 if(rand.Next(0,4) > 0)
        //                 {
        //                     editDachi.Fullness += rand.Next(5,11);
        //                     ViewBag.Reaction = ":)";
        //                     ViewBag.Message = "Your Dachi Enjoyed that meal!";
        //                 }
        //                 else
        //                 {
        //                     ViewBag.Reaction = ":(";
        //                     ViewBag.Message = "Your Dachi didn't like that meal very much...";
        //                 }
        //             }
        //             else
        //             {
        //                 ViewBag.Reaction = ":(";
        //                 ViewBag.Message = "You Don't have any food for your Dachi.";
        //             }
        //             break;
        //         case "play":
        //             if(editDachi.Energy > 4)
        //             {
        //                 editDachi.Energy --;
        //                 if(rand.Next(0,4) > 0)
        //                 {
        //                     editDachi.Happiness += rand.Next(5, 11);
        //                     ViewBag.Reaction = ":)";
        //                     ViewBag.Message = "Your Dachi had fun playing!";
        //                 }
        //                 else
        //                 {
        //                     ViewBag.Reaction = ":(";
        //                     ViewBag.Message = "Your Dachi didn't want to play...";
        //                 }
        //             }
        //             else
        //             {
        //                 ViewBag.Reaction = ":(";
        //                 ViewBag.Message = "You Don't have enough energy.";
        //             }
        //             break;
                    
        //         case "work":
        //             if(editDachi.Energy > 4)
        //             {
        //                 editDachi.Energy -=5;
        //                 editDachi.Meals += rand.Next(1, 4);
        //                 ViewBag.Reaction =":)";
        //                 ViewBag.Message = "You worked hard to feed your Dachi";
        //             }
        //             else
        //             {
        //                 ViewBag.Reaction = ":(";
        //                 ViewBag.Message = "Not enough energy.";
        //             }
        //             break;
        //         case "sleep":
        //             editDachi.Energy += 15;
        //             editDachi.Fullness -=5;
        //             editDachi.Happiness -=5;
        //             ViewBag.Reaction = ":)";
        //             ViewBag.Message = "Your Dachi seems well rested";
        //             break;
        //         default:
        //             ViewBag.Reaction = "XxXxXxXxXxXxXxXxXxXxXxXxXxXxXxXx";
        //             ViewBag.Message = "There's a glitch in the matrix...";
        //             break;
        //     }
            

        //     if(editDachi.Fullness < 1 || editDachi.Happiness < 1)
        //     {
        //         ViewBag.Reaction = "X(";
        //         ViewBag.Message = "Oh no! Your Dachi has Died...";
        //         ViewBag.Status = "over";
        //     }
        //     else if(editDachi.Fullness > 99 && editDachi.Happiness > 99)
        //     {
        //         ViewBag.Reaction = ":D";
        //         ViewBag.Message = "Congratulations! You Win!";
        //         ViewBag.Status = "over";
        //     }

        //     SetDachi(editDachi);
        //     ViewBag.DojoDachi = editDachi;
        //     return View("Index");
        // }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}