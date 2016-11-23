
using Lab6_RyanWall_WebDesign.Models;

namespace Lab6_RyanWall_WebDesign.Services
{
    public class UserService : IUserService
    {
        private readonly ICoolRatingService _coolratingservice;
        public static int Coolthreshold = 70;

        public UserService(ICoolRatingService coolratingservice)
        {
            _coolratingservice = coolratingservice;
        }

        public bool UserIsCool(User user)
        {

            var CoolRating = _coolratingservice.GetCoolRating(user);
            return user.DoYouPlayVG && (user.FavoriteNBATeam.Equals("Blazers") || user.FavoriteNBATeam.Equals("blazers")) && CoolRating > Coolthreshold;

        }
    }


}