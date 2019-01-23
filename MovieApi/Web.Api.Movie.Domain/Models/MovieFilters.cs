using Web.Api.Movie.Domain.Models.Validation;

namespace Web.Api.Movie.Domain.Models
{
    [AtLeastOneProperty(ErrorMessage = "You must supply at least one value")]
    public class MovieFilters
    {
        private string _title;
        public string Title
        {
            get => string.IsNullOrWhiteSpace(_title) ? "" : _title.ToLower();
            set => _title = value;
        }

        public virtual int? YearOfRelease { get; set; }

        private string _genre;
        public string Genre
        {
            get => string.IsNullOrWhiteSpace(_genre) ? "" : _genre.ToLower();
            set => _genre = value;
        }
    }
}
