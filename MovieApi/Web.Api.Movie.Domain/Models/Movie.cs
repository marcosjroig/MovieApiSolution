using System.Collections.Generic;

namespace Web.Api.Movie.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public int RunningTime { get; set; }
        public IList<Rating> Ratings { get; set; }
    }
}
