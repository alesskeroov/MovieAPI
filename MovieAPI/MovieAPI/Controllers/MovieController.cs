using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Movie>> AllMovie()
        {
            var movies= _movieRepository.AllMovie();
            return Ok(movies);
        }
        [HttpGet]
        public ActionResult GetByIdMovie(int id)
        {
            var movie= _movieRepository.GetById(id); 
            return Ok(movie);   
        }
        [HttpPost]
        public ActionResult Post(Movie movie)
        {
            _movieRepository.AddMovie(movie);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(Movie movie,int id)
        {
            _movieRepository.UpdateMovie(movie, id);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _movieRepository.DeleteMovie(id);
            return NoContent();
        }

    }
}
