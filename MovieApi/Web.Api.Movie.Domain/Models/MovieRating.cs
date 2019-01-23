namespace Web.Api.Movie.Domain.Models
{
    public class MovieRating
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Average { get; set; }
    }
}
