using Microsoft.EntityFrameworkCore;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Data.Data
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Models.Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
