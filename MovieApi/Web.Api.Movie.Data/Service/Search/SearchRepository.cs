using System.Collections.Generic;
using System.Linq;
using Web.Api.Movie.Data.Data;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Data.Service.Search
{
    public class SearchRepository: ISearchRepository
    {
        private readonly MovieDbContext _moviesDbContext;
        public SearchRepository(MovieDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public IEnumerable<Domain.Models.Movie> GetAll()
        {
            return _moviesDbContext.Movies;
        }

        public IEnumerable<Domain.Models.Movie> Search(MovieFilters filters)
        {
            return _moviesDbContext.Movies.Where(p => (p.Title.Trim().ToLower().Contains(filters.Title) | string.IsNullOrWhiteSpace(p.Title))
                                                       && (p.Genre.Trim().ToLower().Contains(filters.Genre) | string.IsNullOrWhiteSpace(p.Genre))
                                                       && (p.YearOfRelease == filters.YearOfRelease | filters.YearOfRelease == null)
            );
        }
    }
}
