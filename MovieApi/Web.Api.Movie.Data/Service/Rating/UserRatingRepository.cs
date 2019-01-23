using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Web.Api.Movie.Data.Data;
using Web.Api.Movie.Domain.Models;
using Web.Api.Movie.Utils.Formatters;

namespace Web.Api.Movie.Data.Service.Rating
{
    public class UserRatingRepository : IUserRatingRepository
    {
        private readonly MovieDbContext _moviesDbContext;
        private readonly IDecimalFormatter _formatter;
        public UserRatingRepository(MovieDbContext moviesDbContext, IDecimalFormatter formatter)
        {
            _moviesDbContext = moviesDbContext;
            _formatter = formatter;
        }

        public IEnumerable<MovieRating> GetTopFiveByUser(int userId)
        {
            return _moviesDbContext.Ratings
            .Where(x => x.UserId == userId)
            .GroupBy(r => r.MovieId)
            .Select(group => new MovieRatingRound(_formatter)
            {
                Id = group.Key,
                Title = group.Select(g => g.Movie.Title).FirstOrDefault(),
                Average = group.Average(g => g.RatingValue)
            }).OrderByDescending(s => s.Average).ThenBy(x => x.Title).Take(5).ToList();
        }
    }
}
