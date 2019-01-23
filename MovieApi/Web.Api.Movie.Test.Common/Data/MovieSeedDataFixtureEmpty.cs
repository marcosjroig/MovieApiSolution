using System;
using Microsoft.EntityFrameworkCore;
using Web.Api.Movie.Data.Data;

namespace Web.Api.Movie.Test.Common.Data
{
    public class MovieSeedDataFixtureEmpty : IDisposable
    {
        public MovieDbContext MovieContext { get; }

        public MovieSeedDataFixtureEmpty()
        {
            var databaseName = "MovieListDatabase_" + DateTime.Now.ToFileTimeUtc();
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            MovieContext = new MovieDbContext(options);
        }

        public void Dispose()
        {
            MovieContext.Dispose();
        }
    }
}
