using System;
using Microsoft.EntityFrameworkCore;
using Web.Api.Movie.Data.Data;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Test.Common.Data
{
    public class MovieSeedDataFixture : IDisposable
    {
        public MovieDbContext MovieContext { get; }

        public MovieSeedDataFixture(string name)
        {
            var databaseName = "MovieDatabase_" + name + "_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            MovieContext = new MovieDbContext(options);

            // Load movies
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 1, Title = "John Wick", YearOfRelease = 2015, Genre = "Action", RunningTime = 120 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 2, Title = "Terminator 6", YearOfRelease = 2019, Genre = "Science Fiction/Action", RunningTime = 110 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 3, Title = "John Wick: Chapter 2", YearOfRelease = 2017, Genre = "Action", RunningTime = 130 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 4, Title = "The Saint", YearOfRelease = 2017, Genre = "Action", RunningTime = 120 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 5, Title = "The Interview", YearOfRelease = 2014, Genre = "Action/Comedy", RunningTime = 120 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 6, Title = "Mr. & Mrs. Smith", YearOfRelease = 2005, Genre = "Crime/Thriller", RunningTime = 115 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 7, Title = "Fast & Furious 8", YearOfRelease = 2017, Genre = "Crime/Action", RunningTime = 125 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 8, Title = "Fast & Furious 1", YearOfRelease = 2001, Genre = "Crime/Action", RunningTime = 120 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 9, Title = "Jason Bourne", YearOfRelease = 2016, Genre = "Action", RunningTime = 135 });
            MovieContext.Movies.Add(new Domain.Models.Movie { Id = 10, Title = "Iron Man 3", YearOfRelease = 2013, Genre = "Science Fiction/Action", RunningTime = 110 });

            // Load Users
            MovieContext.Users.Add(new User { Id = 1, FirstName = "John", Lastname = "Doe" });
            MovieContext.Users.Add(new User { Id = 2, FirstName = "Jane", Lastname = "Doe" });

            // Load Ratings
            MovieContext.Ratings.Add(new Rating { Id = 1, MovieId = 1, UserId = 1, RatingValue =   4.1m  });
            MovieContext.Ratings.Add(new Rating { Id = 2, MovieId = 1, UserId = 2, RatingValue =   5.0m  });
            MovieContext.Ratings.Add(new Rating { Id = 3, MovieId = 2, UserId = 1, RatingValue =   4.0m  });
            MovieContext.Ratings.Add(new Rating { Id = 4, MovieId = 2, UserId = 2, RatingValue =   4.0m  });
            MovieContext.Ratings.Add(new Rating { Id = 5, MovieId = 3, UserId = 1, RatingValue =   4.0m  });
            MovieContext.Ratings.Add(new Rating { Id = 6, MovieId = 3, UserId = 2, RatingValue =   4.0m  });
            MovieContext.Ratings.Add(new Rating { Id = 7, MovieId = 4, UserId = 1, RatingValue =   3.249m });
            MovieContext.Ratings.Add(new Rating { Id = 8, MovieId = 4, UserId = 2, RatingValue =   3.249m });
            MovieContext.Ratings.Add(new Rating { Id = 9, MovieId = 5, UserId = 1, RatingValue =   2.0m   });
            MovieContext.Ratings.Add(new Rating { Id = 10, MovieId = 5, UserId = 2, RatingValue =  2.25m  });
            MovieContext.Ratings.Add(new Rating { Id = 11, MovieId = 6, UserId = 1, RatingValue = 1.10m });
            MovieContext.Ratings.Add(new Rating { Id = 12, MovieId = 6, UserId = 2, RatingValue = 1.12m });
            MovieContext.Ratings.Add(new Rating { Id = 13, MovieId = 7, UserId = 1, RatingValue =  1.09m  });
            MovieContext.Ratings.Add(new Rating { Id = 14, MovieId = 8, UserId = 1, RatingValue =  1.08m  });
            MovieContext.Ratings.Add(new Rating { Id = 15, MovieId = 9, UserId = 1, RatingValue =  1.07m  });
            MovieContext.Ratings.Add(new Rating { Id = 16, MovieId = 10, UserId = 1, RatingValue = 1.06m  });

            MovieContext.SaveChanges();
        }

        public void Dispose()
        {
            MovieContext.Dispose();
        }
    }
}
