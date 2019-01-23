using Web.Api.Movie.Domain.Models.Validation;
using Web.Api.Movie.Domain.Test.Models;
using Xunit;

namespace Web.Api.Movie.Domain.Test
{
    public class AtLeastOnePropertyAttributeTest
    {
        private readonly AtLeastOnePropertyAttribute _sut;
        private readonly FakeClass _fakeClass;

        public AtLeastOnePropertyAttributeTest()
        {
            _sut = new AtLeastOnePropertyAttribute();
            _fakeClass = new FakeClass();
        }

        [Fact]
        public void IsValid_ValidIntegerPassed_ReturnsTrue()
        {
            // Arrange
            _fakeClass.Id = 15;

            // Act
            var result = _sut.IsValid(_fakeClass);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_ValidBoolenPassed_ReturnsTrue()
        {
            // Arrange
            _fakeClass.IsValid = true;

            // Act
            var result = _sut.IsValid(_fakeClass);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_AllClassPropertiesEmpty_ReturnsFalse()
        {
            // Act
            var result = _sut.IsValid(_fakeClass);

            // Assert
            Assert.False(result);
        }
    }
}
