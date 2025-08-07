using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.AppDbContext;
using MovieAPI.Entities;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        IRepository _repository;
        public MoviesController(MovieDbContext movieDbContext, IRepository movieRepository)
        {
            _repository = movieRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> MostPopularMovie()
        {
            return Ok(_repository.MostPopularMovie());
        }


        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _repository.GetMovies();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            _repository.AddMovie(movie);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult<Movie> UpdateMovie(int ID, Movie movie)
        {

            _repository.UpdateMovie(ID, movie);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult DeleteMovie(int ID)
        {
            _repository.DeleteMovie(ID);
            return NoContent();
        }

    }
}
