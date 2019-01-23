using System.Collections.Generic;

namespace Web.Api.Movie.Data.Service.Rating
{
    public interface IRatingRepository
    {
        IEnumerable<Domain.Models.Rating> GetAll();
        Domain.Models.Rating GetMovieRating(int userId, int movieId);
        void UpdateRating(Domain.Models.Rating rating);
        void InsertRating(Domain.Models.Rating rating);
    }
}
