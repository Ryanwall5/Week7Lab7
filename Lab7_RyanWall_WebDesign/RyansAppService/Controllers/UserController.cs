using Lab6_RyanWall_WebDesign.Data;
using Lab6_RyanWall_WebDesign.Models;

using System.Collections.Generic;

using System.Web.Http;

namespace RyansAppService.Controllers
{
    public class UserController : ApiController
    {
        private IRepository repository;

        public UserController()
        {

            repository = new EfRepository();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = repository.GetAllUsers();

            return users;
        }


        //User[] users = new User[]
        //{


        //    new User { UserId = 1, FirstName = "Ryan", LastName = "Wall", NickName = "rhino", address = "123 n st", DoYouPlayVG = true, EmailAddress = "thecoolest@yahoo.com", FavoriteNBATeam = "Blazers" },
        //    new User { UserId = 1, FirstName = "mail", LastName = "man", NickName = "mailguy", address = "123 the mail st", DoYouPlayVG = false, EmailAddress = "theffcoolest@yahoo.com", FavoriteNBATeam = "lakers" },
        //    new User { UserId = 1, FirstName = "IceCream", LastName = "man", NickName = "tillamook", address = "123 the icecream st", DoYouPlayVG = true, EmailAddress = "thesscoolest@yahoo.com", FavoriteNBATeam = "bulls" }

        //};

    

        public IHttpActionResult GetUser(int id)
        {
            var user = repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }




    }
}
