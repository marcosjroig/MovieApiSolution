using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service.Rating;

namespace Web.Api.Movie.Controllers
{
    [Route("apic/movies")]
    [ApiController]
    public class MoviesCController : ControllerBase
    {
        private readonly IUserRatingRepository _repository;

        public MoviesCController(IUserRatingRepository repository)
        {
            _repository = repository;
        }

        // GET: apic/movies
        [HttpGet]
        public IActionResult GetTopFiveByUser(int userId)
        {
            var movies = _repository.GetTopFiveByUser(userId);
            if (movies != null && !movies.Any())
            {
                return NotFound("No records found in the Database");
            }

            return Ok(movies);
        }
    }
}
