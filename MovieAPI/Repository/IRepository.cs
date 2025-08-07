using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;

namespace MovieAPI.Repository
{
    public interface IRepository
    {
        public ActionResult<IEnumerable<Movie>> GetMovies();
        public ActionResult<IEnumerable<Movie>> MostPopularMovie();
        public bool AddMovie(Movie movie);
        public bool UpdateMovie(int ID, Movie movie);
        public bool DeleteMovie(int ID);
    }
}
