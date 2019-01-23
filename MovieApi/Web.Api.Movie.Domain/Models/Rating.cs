using System.ComponentModel.DataAnnotations;

namespace Web.Api.Movie.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [RegularExpression("^[1-5]", ErrorMessage = "Only integers from 1 to 5 are allowed")]
        [Required]
        public decimal RatingValue { get; set; }
        public Movie Movie { get; set; }
    }
}
