using Microsoft.AspNetCore.Mvc;
using Web.Api.Movie.Data.Service.Movie;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Data.Service.User;
using Web.Api.Movie.Domain.Models;

namespace Web.Api.Movie.Controllers
{
    [Route("apid/movies")]
    [ApiController]
    public class MoviesDController : ControllerBase
    {
        private readonly IRatingRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        public MoviesDController(IRatingRepository repository, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        // POST: apid/movies
        [HttpPost]
        public IActionResult Upsert([FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //1) Get the User
            var user = _userRepository.GetById(rating.UserId);
            if (user == null)
            {
                return NotFound("User not found...");
            }

            //2) Get the Movie
            var movie = _movieRepository.GetById(rating.MovieId);
            if (movie == null)
            {
                return NotFound("Movie not found...");
            }

            //3) Get Rating
            var existingRating = _repository.GetMovieRating(rating.UserId, rating.MovieId);
            if (existingRating == null)
            {
                //Insert
                _repository.InsertRating(rating);

                return Ok("Rating added");
            }

            existingRating.RatingValue = rating.RatingValue;
            //Update
            _repository.UpdateRating(existingRating);

            return Ok("Rating updated");
        }
    }
}
