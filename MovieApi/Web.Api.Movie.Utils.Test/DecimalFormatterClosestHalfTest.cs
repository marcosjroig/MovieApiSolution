using Web.Api.Movie.Utils.Formatters;
using Xunit;

namespace Web.Api.Movie.Utils.Test
{
    public class DecimalFormatterClosestHalfTest
    {
        private readonly IDecimalFormatter _sut;

        public DecimalFormatterClosestHalfTest()
        {
            _sut = new DecimalFormatterClosestHalf();
        }

        [Fact]
        public void Convert_WhenCalled_ReturnsTheRigthRouding()
        {
            // Arrange
            var number1 = 2.91m;
            var number2 = 3.249m;
            var number3 = 3.25m;
            var number4 = 3.6m;
            var number5 = 3.75m;

            // Act
            var result1 = _sut.Convert(number1);
            var result2 = _sut.Convert(number2);
            var result3 = _sut.Convert(number3);
            var result4 = _sut.Convert(number4);
            var result5 = _sut.Convert(number5);

            // Assert
            Assert.Equal(3.0m, result1);
            Assert.Equal(3.0m, result2);
            Assert.Equal(3.5m, result3);
            Assert.Equal(3.5m, result4);
            Assert.Equal(4.0m, result5);
        }
    }
}

