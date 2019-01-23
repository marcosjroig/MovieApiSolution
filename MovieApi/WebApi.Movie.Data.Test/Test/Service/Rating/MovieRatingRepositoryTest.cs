using System.Linq;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Test.Common.Data;
using Web.Api.Movie.Utils.Formatters;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.Rating
{
    public class MovieRatingRepositoryTest
    {
        private readonly IMovieRatingRepository _sut;
        
        public MovieRatingRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("MovieRatingRepository");
            IDecimalFormatter formatter = new DecimalFormatterClosestHalf();
            _sut = new MovieRatingRepository(fixture.MovieContext, formatter);
        }

        [Fact]
        public void GetTopFiveMovies_WhenCalled_ReturnsFiveMovies()
        {
            //Act
            var movies = _sut.GetTopFive();

            //Assert
            Assert.Equal(5, movies.Count());
        }

        [Fact]
        public void GetTopFiveMovies_WhenCalled_ReturnsTheRightTopOneRanked()
        {
            //Act
            var movies = _sut.GetTopFive();

            //Assert
            Assert.Equal(5, movies.Count());
            Assert.Equal("John Wick", movies.ToList()[0].Title);
        }

        [Fact]
        public void GetTopFiveMovies_InCaseOfRatingDraw_ReturnsAscendingTitleAlphabeticalOrder()
        {
            //Act
            var movies = _sut.GetTopFive();

            //Assert
            Assert.Equal(5, movies.Count());
            Assert.Equal("John Wick: Chapter 2", movies.ToList()[1].Title);
            Assert.Equal("Terminator 6", movies.ToList()[2].Title);
        }

        [Fact]
        public void GetTopFiveMovies_WhenCalled_ReturnsTheRightRatingRounding()
        {
            //Act
            var movies = _sut.GetTopFive();

            //Assert
            Assert.Equal(4.5m, movies.ToList()[0].Average);
            Assert.Equal(3.0m, movies.ToList()[3].Average);
        }
    }
}
