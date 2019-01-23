using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Domain.Models;
using Web.Api.Movie.Controllers;
using Web.Api.Movie.Data.Service.Search;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace Web.Api.Movie.Test.Test.Controllers
{
    public class MoviesAControllerTest
    {
        private readonly MovieFilters _filters;
        private readonly MoviesAController _controller;

        public MoviesAControllerTest()
        {
            var fixture = new MovieSeedDataFixture("MoviesAController");
            var repository = new SearchRepository(fixture.MovieContext);
            _filters = new MovieFilters { Genre = "Action" };
            _controller = new MoviesAController(repository);
        }

        [Fact]
        public void Search_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Search(_filters);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Search_WhenCalled_ReturnsSubsetOfMvoies()
        {
            // Act
            var okResult = _controller.Search(_filters) as OkObjectResult;
            var movies = okResult.Value as IEnumerable<Domain.Models.Movie>;

            // Assert
            Assert.Equal(9, movies.Count());
        }

        [Fact]
        public void Search_WhenCalled_ReturnsTheRightItem()
        {
            // Arrange
            _filters.Title = "John Wick: Chapter 2";

            // Act
            var okResult = _controller.Search(_filters) as OkObjectResult;
            var movies  = okResult.Value as IEnumerable<Domain.Models.Movie> ;

            // Assert
            Assert.Single(movies);
            Assert.Equal("John Wick: Chapter 2", movies.ToList()[0].Title);
        }

        [Fact]
        public void Search_EmptyParametersPassed_ReturnsBadRequest()
        {
            // Act
            _controller.ModelState.AddModelError("Validation Error", "You must supply at least one value");
            var result = _controller.Search(new MovieFilters());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Search_WithUnexistingYearOfRelease_ReturnsNotFound()
        {
            // Act
            var result = _controller.Search(new MovieFilters {YearOfRelease = 2020});

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
