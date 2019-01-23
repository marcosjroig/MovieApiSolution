using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service;
using Web.Api.Movie.Data.Service.User;

namespace Web.Api.Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }
    }
}
