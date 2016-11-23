using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6_RyanWall_WebDesign.Models;

namespace Lab6_RyanWall_WebDesign.Services
{
    public class CoolRatingService : ICoolRatingService
    {
        
        public int GetCoolRating(User user)
        {
            int rating = 0;

            if (user.FavoriteNBATeam == "blazers" || user.FavoriteNBATeam == "Blazers")
                rating = 100;

            else if (user.FavoriteNBATeam == "Warriors" || user.FavoriteNBATeam == "warriors")
                rating = 0;

            else
                rating = 50;

            return rating;
        }
    }
}