using System.Collections.Generic;

namespace Web.Api.Movie.Data.Service.User
{
    public interface IUserRepository
    {
        IEnumerable<Domain.Models.User> GetAll();
        Domain.Models.User GetById(int userId);
    }
}

