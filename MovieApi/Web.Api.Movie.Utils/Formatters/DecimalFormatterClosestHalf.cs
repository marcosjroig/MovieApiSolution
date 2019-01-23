using System;

namespace Web.Api.Movie.Utils.Formatters
{
    public class DecimalFormatterClosestHalf : IDecimalFormatter
    {
        public decimal Convert(decimal number)
        {
            return Math.Round(number * 2, MidpointRounding.AwayFromZero) / 2;
        }
    }
}
