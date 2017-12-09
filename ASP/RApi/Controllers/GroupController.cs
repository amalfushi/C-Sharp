using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists { get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]
        public JsonResult AllGroups()
        {
            return Json(allGroups);
        }

        [Route("groups/{name}/{listArtists}")]
        [HttpGet]
        public JsonResult OneGroup(string name, bool listArtists)
        {
            List<Group> oneGroup = allGroups.FindAll(g => g.GroupName == name).ToList();
            if(listArtists)
            {
                oneGroup = oneGroup.GroupJoin(allArtists, g => g.Id, a => a.GroupId, (g, a)=> {g.Members = a.ToList(); return g;}).ToList();
            }
            return Json(oneGroup);
        }

        [Route("groups/id/{id}/{listArtists}")]
        [HttpGet]
        public JsonResult AllGroupsFromID(int id, bool listArtists)
        {
            List<Group> oneGroup = allGroups.FindAll(g => g.Id == id).ToList();
            if(listArtists)
            {
                oneGroup = oneGroup.GroupJoin(allArtists, g => g.Id, a => a.GroupId, (g, a)=> {g.Members = a.ToList(); return g;}).ToList();
            }
            return Json(oneGroup);
        }
    }
}