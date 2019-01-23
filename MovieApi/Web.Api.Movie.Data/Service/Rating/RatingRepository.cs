using System.Collections.Generic;
using System.Linq;
using Web.Api.Movie.Data.Data;

namespace Web.Api.Movie.Data.Service.Rating
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieDbContext _moviesDbContext;
        public RatingRepository(MovieDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public IEnumerable<Domain.Models.Rating> GetAll()
        {
           return _moviesDbContext.Ratings;  
        }

        public Domain.Models.Rating GetMovieRating(int userId, int movieId)
        {
            return _moviesDbContext.Ratings.SingleOrDefault(x => x.UserId == userId && x.MovieId == movieId);
        }

        public void UpdateRating(Domain.Models.Rating rating)
        {
            _moviesDbContext.Ratings.Update(rating);
            _moviesDbContext.SaveChanges(true);
        }

        public void InsertRating(Domain.Models.Rating rating)
        {
            _moviesDbContext.Ratings.Add(rating);
            _moviesDbContext.SaveChanges(true);
        }
    }
}
