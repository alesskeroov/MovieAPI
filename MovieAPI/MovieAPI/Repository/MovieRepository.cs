using Microsoft.EntityFrameworkCore;
using MovieAPI.AppDbContext;
using MovieAPI.Dtos;
using MovieAPI.Entities;

namespace MovieAPI.Repository
{
    public class MovieRepository:IMovieRepository
    {
        readonly MovieDbContext _dbContext;
        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<MovieDto> AllMovie()
        {
            return _dbContext.Movies.Include(m=>m.Genre).Select(m=> new MovieDto
            {
                Id=m.Id,
                Title = m.Title,
                Description = m.Description,
                Imdb = m.IMDB,
                Director = m.Director,
                GenreName = m.Genre.Name
            }).ToList();
        }

        public bool DeleteMovie(int id)
        {
            var movie= _dbContext.Movies.Find(id);
            if(movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Movie GetById(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            return movie;
        }

        public bool UpdateMovie(Movie movie, int id)
        {
            var data = _dbContext.Movies.Find(id);
            if(data != null)
            {
                data.Title = movie.Title;
                data.IMDB = movie.IMDB;
                data.Director = movie.Director;
                data.Description = movie.Description;
                data.Genre = movie.Genre;
                return true;
            }
            return false;
        }
    }
}
