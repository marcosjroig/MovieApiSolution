using Web.Api.Movie.Utils.Formatters;

namespace Web.Api.Movie.Domain.Models
{
    public class MovieRatingRound : MovieRating
    {
        private readonly IDecimalFormatter _formatter;
        public MovieRatingRound(IDecimalFormatter formatter)
        {
            _formatter = formatter;
        }

        private decimal _avarage;
        public override decimal Average
        {
            get => _formatter.Convert(_avarage);
            set => _avarage = value;
        }
    }
}
