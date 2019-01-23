using System.Collections.Generic;

namespace Web.Api.Movie.Data.Service.Movie
{
    public interface IMovieRepository
    {
        IEnumerable<Domain.Models.Movie> GetAll();
        Domain.Models.Movie GetById(int movieId);
    }
}
