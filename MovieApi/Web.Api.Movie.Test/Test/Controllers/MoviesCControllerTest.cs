using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Controllers;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Domain.Models;
using Web.Api.Movie.Test.Common.Data;
using Web.Api.Movie.Utils.Formatters;
using Xunit;

namespace Web.Api.Movie.Test.Test.Controllers
{
    public class MoviesCControllerTest
    {
        private readonly MoviesCController _controller;
        private readonly IDecimalFormatter _formatter;
        private const int UserId = 1;

        public MoviesCControllerTest()
        {
            var fixture = new MovieSeedDataFixture("MoviesCController");
            _formatter = new DecimalFormatterClosestHalf();
            var repository = new UserRatingRepository(fixture.MovieContext, _formatter);
            _controller = new MoviesCController(repository);
        }

        [Fact]
        public void GetTopFiveByUser_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetTopFiveByUser(UserId);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetTopFiveByUser_WhenCalled_ReturnsFiveMovies()
        {
            // Act
            var okResult = _controller.GetTopFiveByUser(UserId) as OkObjectResult;
            var moviesRating = okResult.Value as IEnumerable<MovieRating>;

            // Assert
            Assert.Equal(5, moviesRating.Count());
        }

        [Fact]
        public void GetTopFiveByUser_WhenCalled_ReturnsTheRightTopOneRanked()
        {
            //Act
            var okResult = _controller.GetTopFiveByUser(UserId) as OkObjectResult;
            var moviesRating = okResult.Value as IEnumerable<MovieRating>;

            //Assert
            Assert.Equal(5, moviesRating.Count());
            Assert.Equal("John Wick", moviesRating.ToList()[0].Title);
        }

        [Fact]
        public void GetTopFiveByUser_WithEmptyMovies_ReturnsNotFound()
        {
            // Arrange
            var fixture = new MovieSeedDataFixtureEmpty();
            var repository = new UserRatingRepository(fixture.MovieContext, _formatter);
            var controllerWithEmptyMovies = new MoviesCController(repository);

            // Act
            var result = controllerWithEmptyMovies.GetTopFiveByUser(UserId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
