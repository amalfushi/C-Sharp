using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [Route("artists")]
        [HttpGet]
        public JsonResult AllArtists()
        {
            return Json(allArtists);
        }

        [Route("artists/{name}")]
        [HttpGet]
        public JsonResult OneArtist(string name)
        {
            return Json(allArtists.FindAll(a => a.ArtistName == name));
        }

        [Route("artists/realname/{name}")]
        [HttpGet]
        public JsonResult OneRealName(string name)
        {
            return Json(allArtists.FindAll(a => a.RealName == name));
        }

        [Route("artists/hometown/{town}")]
        [HttpGet]
        public JsonResult AllHometown(string town)
        {
            return Json(allArtists.FindAll(a => a.Hometown == town));
        }

        [Route("artists/groupid/{id}")]
        [HttpGet]
        public JsonResult AllFromGroup(int id)
        {
            // .Join(Groups, a => a.GroupId, g => g.Id, (a, g)=>{ a.Group = g; return a; })
            return Json(allArtists.FindAll(a => a.GroupId == id));
        }
    }
}