using System.Collections.Generic;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Data.Service.Rating
{
    public interface IMovieRatingRepository
    {
        IEnumerable<MovieRating> GetTopFive();
    }
}
