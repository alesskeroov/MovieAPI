using MovieAPI.Dtos;
using MovieAPI.Entities;

namespace MovieAPI.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<MovieDto> AllMovie();
        Movie GetById(int id);
        bool AddMovie(Movie movie);
        bool UpdateMovie(Movie movie,int id);
        bool DeleteMovie(int id);
    }
}
