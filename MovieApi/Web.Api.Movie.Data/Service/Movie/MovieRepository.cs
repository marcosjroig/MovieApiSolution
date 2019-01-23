using System.Collections.Generic;
using System.Linq;
using Web.Api.Movie.Data.Data;

namespace Web.Api.Movie.Data.Service.Movie
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _moviesDbContext;
        public MovieRepository(MovieDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public IEnumerable<Domain.Models.Movie> GetAll()
        {
            return _moviesDbContext.Movies;
        }

        public Domain.Models.Movie GetById(int movieId)
        {
            return _moviesDbContext.Movies.SingleOrDefault(x => x.Id == movieId);
        }
    }
}
