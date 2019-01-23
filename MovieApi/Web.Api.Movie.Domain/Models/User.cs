using System.ComponentModel.DataAnnotations;

namespace Web.Api.Movie.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
    }
}
