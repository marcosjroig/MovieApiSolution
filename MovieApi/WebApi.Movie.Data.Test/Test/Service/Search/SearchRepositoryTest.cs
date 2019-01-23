using System.Linq;
using Web.Api.Movie.Data.Service.Search;
using Web.Api.Movie.Domain.Models;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.Search
{
    public class SearchRepositoryTest
    {
        private readonly ISearchRepository _sut;
        private readonly MovieFilters _filters;

        public SearchRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("SearchRepository");
            _sut = new SearchRepository(fixture.MovieContext);
            _filters = new MovieFilters { Genre = "Action" };
        }

        [Fact]
        public void Search_WhenCalled_ReturnsSubsetOfMvoies()
        {
            //Act
            var movies = _sut.Search(_filters);

            //Assert
            Assert.Equal(9, movies.Count());
        }

        [Fact]
        public void Search_ValidTitlePassed_ReturnsOneMovie()
        {
            // Arrange
            _filters.Title = "The Saint";

            //Act
            var movies = _sut.Search(_filters);

            //Assert
            Assert.Single(movies);
        }

        [Fact]
        public void Search_WithEmptyParameters_ReturnsAllItems()
        {
            //Act
            var movies = _sut.Search(new MovieFilters());

            //Assert
            Assert.Equal(10, movies.Count());
        }
    }
}
