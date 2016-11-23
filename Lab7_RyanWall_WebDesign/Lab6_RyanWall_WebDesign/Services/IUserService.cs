using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6_RyanWall_WebDesign.Models;

namespace Lab6_RyanWall_WebDesign
{
    public interface IUserService
    {
       bool UserIsCool(User user);
    }
}