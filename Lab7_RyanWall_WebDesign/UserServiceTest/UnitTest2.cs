using NUnit.Framework;
using Lab6_RyanWall_WebDesign.Services;
using Lab6_RyanWall_WebDesign.Models;



namespace UserServiceTest
{
    [TestFixture]
    public class UnitTest2
    {
        private ICoolRatingService coolratingservice;

        [SetUp]
        public void SetUp()
        {
            coolratingservice = new CoolRatingService();
        }


        [TestCase]
        public void Test1()
        {
            Assert.IsTrue(true);
        }

        [TestCase]
        public void WhenBlazersOurFavoriteTeamRatingShouldBe100()
        {
            // Arrange
            var user = new User();
            user.FavoriteNBATeam = "blazers";
            var expectedRating = 100;

            // Act
            var rating = coolratingservice.GetCoolRating(user);

            // Assert
            Assert.AreEqual(expectedRating, rating);
        }






    }
}
