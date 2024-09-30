using MovieTrackingAPP.Models;

namespace MovieTrackingAPP.Interfaces;

public interface IMovieService
{
    Task<List<Movie>> GetPopularMovies();
}