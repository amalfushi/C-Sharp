using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]
        public JsonResult AllGroups()
        {
            return Json(allGroups);
        }

        [Route("groups/{name}")]
        [HttpGet]
        public JsonResult OneGroup(string name)
        {
            return Json(allGroups.FindAll(g => g.GroupName == name));
        }

        [Route("groups/id/{id}")]
        [HttpGet]
        public JsonResult AllGroupsFromID(int id)
        {
            // .Join(Groups, a => a.GroupId, g => g.Id, (a, g)=>{ a.Group = g; return a; })
            return Json(allGroups.FindAll(g => g.Id == id));
        }
    }
}