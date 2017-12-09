using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard
{
    public class CallingCard: Controller
    {
        [HttpGetAttribute]
        [Route("")]
        public string Index()
        {
            return @"
            Welcome to Calling Card!!!!
            
            
            Please enter '/FirstName/LastName/Age/FavoriteColor' into the url bar";
        }

        [HttpGet]
        [Route("{first_name}/{last_name}/{age}/{fav_color}")]
        public JsonResult makeJson(string first_name, string last_name, int age, string fav_color)
        {
            var Person = new {
                First_Name = first_name,
                Last_Name = last_name,
                Age = age,
                Favorite_Color = fav_color
            };

            return Json(Person);
        }
    }
}