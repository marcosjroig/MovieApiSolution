using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service.Search;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Controllers
{
    [Route("apia/movies")]
    [ApiController]
    public class MoviesAController : ControllerBase
    {
        private readonly ISearchRepository _repository;

        public MoviesAController(ISearchRepository repository)
        {
            _repository = repository;
        }

        // GET apia/movies
        [HttpGet]
        public IActionResult Search([FromBody] MovieFilters filters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movies = _repository.Search(filters);
            if (movies != null && !movies.Any())
            {
                return NotFound("No records found for the search criteria entered");
            }

            return Ok(movies);
        }
    }
}
