using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Controllers;
using Web.Api.Movie.Data.Service.Movie;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Data.Service.User;
using Web.Api.Movie.Domain.Models;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace Web.Api.Movie.Test.Test.Controllers
{
    public class MoviesDControllerTest
    {
        private const int UserId = 1;
        private const int MovieId = 1;
        private readonly MoviesDController _controller;
        private readonly RatingRepository _repository;

        public MoviesDControllerTest()
        {
            var fixture = new MovieSeedDataFixture("MoviesDController");
            _repository = new RatingRepository(fixture.MovieContext);
            var userRepository = new UserRepository(fixture.MovieContext);
            var movieRepository = new MovieRepository(fixture.MovieContext);
            _controller = new MoviesDController(_repository, userRepository, movieRepository);
        }

        [Fact]
        public void Upsert_ForExistingRating_UpdateTheRatingValue()
        {
            //Act
            var ratingBefore = _repository.GetMovieRating(UserId, MovieId);

            //Assert
            Assert.Equal(4.1m, ratingBefore.RatingValue);

            //Arrange
            var rating = new Rating {Id = 1, UserId = UserId, MovieId = MovieId, RatingValue = 4.5m};
            
            //Act
            _controller.Upsert(rating);
            var ratingAfter = _repository.GetMovieRating(UserId, MovieId);

            //Assert
            Assert.Equal(4.5m, ratingAfter.RatingValue);
        }

        [Fact]
        public void Upsert_ForNonExistingRating_AddNewRatingRow()
        {
            //Arrange
            var rating = new Rating { Id = 17, UserId = 2, MovieId = 9, RatingValue = 2.5m };

            //Act
            _controller.Upsert(rating);
            var newRating = _repository.GetMovieRating(2, 9);

            //Assert
            Assert.Equal(2.5m, newRating.RatingValue);
            Assert.Equal(2, newRating.UserId);
            Assert.Equal(9, newRating.MovieId);
        }

        [Fact]
        public void Upsert_ForUnexistingUser_ReturnNotFound()
        {
            //Arrange
            var rating = new Rating { Id = 1, UserId = 3, MovieId = MovieId, RatingValue = 4.5m };

            //Act
            var result = _controller.Upsert(rating);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Upsert_ForUnexistingMovie_ReturnNotFound()
        {
            //Arrange
            var rating = new Rating { Id = 1, UserId = 1, MovieId = 50, RatingValue = 4.5m };

            //Act
            var result = _controller.Upsert(rating);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Upsert_WithInvalidRating_ReturnsBadRequest()
        {
            //Arrange
            var rating = new Rating { Id = 1, UserId = 1, MovieId = 1, RatingValue = 6 };

            // Act
            _controller.ModelState.AddModelError("Validation Error", "Only integers from 1 to 5 are allowed");
            var result = _controller.Upsert(rating);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
