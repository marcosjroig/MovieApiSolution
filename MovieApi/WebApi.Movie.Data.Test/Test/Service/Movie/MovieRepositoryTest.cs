using System.Linq;
using Web.Api.Movie.Data.Service.Movie;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.Movie
{
    public class MovieRepositoryTest
    {
        private readonly IMovieRepository _sut;
        public MovieRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("MovieRepository");
            _sut = new MovieRepository(fixture.MovieContext);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsTenMovies()
        {
            //Act
            var movies = _sut.GetAll();

            //Assert
            Assert.Equal(10, movies.Count());
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOneMovie()
        {
            //Act
            var movie = _sut.GetById(1);

            //Assert
            Assert.Equal(1, movie.Id);
            Assert.Equal("John Wick", movie.Title);
        }

        [Fact]
        public void GetById_ForUnexistingMovie_ReturnsEmpty()
        {
            //Act
            var movie = _sut.GetById(11);

            //Assert
            Assert.Null(movie);
        }
    }
}
