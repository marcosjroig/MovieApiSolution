using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service.Rating;

namespace Web.Api.Movie.Controllers
{
    [Route("apib/movies")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesBController : ControllerBase
    {
        private readonly IMovieRatingRepository _repository;

        public MoviesBController(IMovieRatingRepository repository)
        {
            _repository = repository;
        }

        // GET apib/movies
        [HttpGet]
        public IActionResult GetTopFive()
        {
            var movies = _repository.GetTopFive();
            if (movies != null && !movies.Any())
            {
                return NotFound("No records found in the Database");
            }

            return Ok(movies);
        }
    }
}