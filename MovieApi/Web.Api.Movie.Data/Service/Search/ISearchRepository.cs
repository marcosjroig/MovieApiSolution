using System.Collections.Generic;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Data.Service.Search
{
    public interface ISearchRepository
    {
        IEnumerable<Domain.Models.Movie> Search(MovieFilters filters);
    }
}
