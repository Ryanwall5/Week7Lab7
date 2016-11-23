using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6_RyanWall_WebDesign.Models;

namespace Lab6_RyanWall_WebDesign.Services
{
    public interface ICoolRatingService
    {
        int GetCoolRating(User user);
    }
}