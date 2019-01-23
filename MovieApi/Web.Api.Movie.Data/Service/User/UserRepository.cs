using System.Collections.Generic;
using System.Linq;
using Web.Api.Movie.Data.Data;

namespace Web.Api.Movie.Data.Service.User
{
    public class UserRepository: IUserRepository
    {
        private readonly MovieDbContext _moviesDbContext;
        public UserRepository(MovieDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public IEnumerable<Domain.Models.User> GetAll()
        {
            return _moviesDbContext.Users;
        }

        public Domain.Models.User GetById(int userId)
        {
            return _moviesDbContext.Users.SingleOrDefault(x => x.Id == userId);
        }
    }
}
