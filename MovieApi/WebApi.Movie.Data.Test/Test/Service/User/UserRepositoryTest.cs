using System.Linq;
using Web.Api.Movie.Data.Service.User;
using Web.Api.Movie.Test.Common.Data;
using Xunit;

namespace WebApi.Movie.Data.Test.Test.Service.User
{
    public class UserRepositoryTest
    {
        private readonly IUserRepository _sut;
        public UserRepositoryTest()
        {
            var fixture = new MovieSeedDataFixture("UserRepository");
            _sut = new UserRepository(fixture.MovieContext);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsTwoUsers()
        {
            //Act
            var users = _sut.GetAll();

            //Assert
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOneUser()
        {
            //Act
            var user = _sut.GetById(1);

            //Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("John", user.FirstName);
            Assert.Equal("Doe", user.Lastname);
        }

        [Fact]
        public void GetById_ForUnexistingUser_ReturnsEmpty()
        {
            //Act
            var user = _sut.GetById(3);

            //Assert
            Assert.Null(user);
        }
    }
}
