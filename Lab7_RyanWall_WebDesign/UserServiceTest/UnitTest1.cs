
using NUnit.Framework;
using Lab6_RyanWall_WebDesign.Services;
using Lab6_RyanWall_WebDesign.Models;
using Lab6_RyanWall_WebDesign;

namespace UserServiceTest.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private ICoolRatingService coolratingservice;
        private IUserService userservice;

        [SetUp]
        public void SetUp()
        {
            coolratingservice = new CoolRatingService();
            userservice = new UserService(coolratingservice);

        }

        [TestCase]
        public void CoolRatingIsBelowThresholdTheUserIsNotCool()
        {
            var user = new User
            {
                FirstName = "frank",
                LastName = "cool",
                EmailAddress = "coolness@gmail.com",
                NickName = "ghost",
                address = "998 cool st",
                FavoriteNBATeam = "lakers",
                DoYouPlayVG = false
                
          
                
            };

            var result = userservice.UserIsCool(user);

            Assert.IsFalse(result);
        }
    }
}
