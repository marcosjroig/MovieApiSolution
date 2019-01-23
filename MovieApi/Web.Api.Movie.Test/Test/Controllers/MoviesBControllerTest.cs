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
    public class MoviesBControllerTest
    {
        private readonly MoviesBController _controller;
        private readonly IDecimalFormatter _formatter;

        public MoviesBControllerTest()
        {
            var fixture = new MovieSeedDataFixture("MoviesBController");
            _formatter = new DecimalFormatterClosestHalf();
            var repository = new MovieRatingRepository(fixture.MovieContext, _formatter);
            _controller = new MoviesBController(repository);
        }

        [Fact]
        public void GetTopFive_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetTopFive();

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetTopFive_WhenCalled_ReturnsFiveMovies()
        {
            // Act
            var okResult = _controller.GetTopFive() as OkObjectResult;
            var moviesRating = okResult.Value as IEnumerable<MovieRating>;

            // Assert
            Assert.Equal(5, moviesRating.Count());
        }

        [Fact]
        public void GetTopFiveMovies_WhenCalled_ReturnsTheRightTopOneRanked()
        {
            //Act
            var okResult = _controller.GetTopFive() as OkObjectResult;
            var moviesRating = okResult.Value as IEnumerable<MovieRating>;

            //Assert
            Assert.Equal(5, moviesRating.Count());
            Assert.Equal("John Wick", moviesRating.ToList()[0].Title);
        }

        [Fact]
        public void GetTopFiveMovies_WithEmptyMovies_ReturnsNotFound()
        {
            // Arrange
            var fixture = new MovieSeedDataFixtureEmpty();
            var repository = new MovieRatingRepository(fixture.MovieContext, _formatter);
            var controllerWithEmptyMovies = new MoviesBController(repository);
            
            // Act
            var result = controllerWithEmptyMovies.GetTopFive();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
