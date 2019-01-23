using System.Linq;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Test.Common.Data;
using Web.Api.Movie.Utils.Formatters;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.Rating
{
    public class UserRatingRepositoryTest
    {
        private readonly IUserRatingRepository _sut;
        private readonly int userId = 1;
        public UserRatingRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("UserRatingRepository");
            IDecimalFormatter formatter = new DecimalFormatterClosestHalf();
            _sut = new UserRatingRepository(fixture.MovieContext, formatter);
        }

        [Fact]
        public void GetTopFiveMoviesByUser_WhenCalled_ReturnsFiveMovies()
        {
            //Act
            var movieRating = _sut.GetTopFiveByUser(userId);

            //Assert
            Assert.Equal(5, movieRating.Count());
        }

        [Fact]
        public void GetTopFiveMoviesByUser_WhenCalled_ReturnsTheRightTopOneRanked()
        {
            //Act
            var movieRating = _sut.GetTopFiveByUser(userId);

            //Assert
            Assert.Equal(5, movieRating.Count());
            Assert.Equal("John Wick", movieRating.ToList()[0].Title);
        }

        [Fact]
        public void GetTopFiveMoviesByUser_InCaseOfRatingDraw_ReturnsAscendingTitleAlphabeticalOrder()
        {
            //Act
            var movieRating = _sut.GetTopFiveByUser(userId);

            //Assert
            Assert.Equal(5, movieRating.Count());
            Assert.Equal("John Wick: Chapter 2", movieRating.ToList()[1].Title);
            Assert.Equal("Terminator 6", movieRating.ToList()[2].Title);
        }
    }
}
