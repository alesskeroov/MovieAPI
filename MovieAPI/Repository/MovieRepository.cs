using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.AppDbContext;
using MovieAPI.Entities;

namespace MovieAPI.Repository
{
    public class MovieRepository : IRepository
    {
        MovieDbContext _db;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _db = movieDbContext;
        }

        public bool AddMovie(Movie movie)
        {
            if (movie != null)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return true;
            }
            return false;


        }

        public bool DeleteMovie(int ID)
        {

            var item = _db.Movies.FirstOrDefault(m => m.MovieId == ID);
            _db.Movies.Remove(item);

            _db.SaveChanges();
            return true;
        }

        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _db.Movies.ToList();
        }

        public ActionResult<IEnumerable<Movie>> MostPopularMovie()
        {
            var values= _db.Movies.Where(m => m.IMDB > 8).ToList();
            return values;
        }

        public bool UpdateMovie(int ID, Movie movie)
        {
            var item = _db.Movies.FirstOrDefault(m => m.MovieId == ID);
            if (item != null)
            {
                item.MovieName = movie.MovieName;
                item.IMDB = movie.IMDB;
                item.Year = movie.Year;
                item.Description = movie.Description;
                item.Actors = movie.Actors;
                return true;
            }
            _db.SaveChanges();

            return false;

        }
    }
}
