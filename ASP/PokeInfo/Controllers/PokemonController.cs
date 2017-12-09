using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult Index(int id)
        {
            Dictionary<string, object>PokeObj = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObj = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObj;
            Console.WriteLine(PokeObj["name"]);
            return View();
        }
    }
}
