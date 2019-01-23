using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.Rating
{
    public class RatingRepositoryTest
    {
        private readonly IRatingRepository _sut;
        private const int UserId = 1;
        private const int MovieId = 1;

        public RatingRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("RatingRepository");
            _sut = new RatingRepository(fixture.MovieContext);
        }

        [Fact]
        public void GetMovieRating_WhenCalled_ReturnsOneMovieRating()
        {
            //Act
            var rating = _sut.GetMovieRating(UserId, MovieId);

            //Assert
            Assert.Equal(1, rating.MovieId);
            Assert.Equal(1, rating.UserId);
            Assert.Equal(4.1m, rating.RatingValue);
        }

        [Fact]
        public void UpdateRating_ForExistingRating_UpdateTheRatingValue()
        {
            //Act
            var ratingBefore = _sut.GetMovieRating(UserId, MovieId);

            //Assert
            Assert.Equal(4.1m, ratingBefore.RatingValue);

            //Arrange
            var rating = _sut.GetMovieRating(UserId, MovieId);
            rating.RatingValue = 4.5m;

            //Act
            _sut.UpdateRating(rating);
            var ratingAfter = _sut.GetMovieRating(UserId, MovieId);

            //Assert
            Assert.Equal(4.5m, ratingAfter.RatingValue);
        }

        [Fact]
        public void InserRating_WhenCalled_AddNewRatingRow()
        {
            //Arrange
            var rating = new Web.Api.Movie.Domain.Models.Rating {Id = 17, MovieId = 10, UserId = 2, RatingValue = 1.5m};
            
            //Act
            _sut.InsertRating(rating);
            var newRating = _sut.GetMovieRating(2, 10);

            //Assert
            Assert.Equal(10, newRating.MovieId);
            Assert.Equal(2, newRating.UserId);
            Assert.Equal(1.5m, newRating.RatingValue);
        }
    }
}



