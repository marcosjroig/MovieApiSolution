using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service.Rating;

namespace Web.Api.Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingRepository _repository;

        public RatingsController(IRatingRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Ratings
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
    }
}
