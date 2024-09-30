using Microsoft.AspNetCore.Mvc;
using MovieTrackingAPP.Services;
using MovieTrackingAPP.Interfaces;

namespace MovieTrackingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
    
        // Inyect the mvoieservice
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        // We get the popular movies
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMoviesAsync()
        {
            try
            {
                // We call the service that retrive the information from the API
                var movies = await _movieService.GetPopularMovies();
                
                // Check if we got the movies
                if (movies.Count > 0)
                {
                    return Ok(movies);
                }
                else
                {
                    return NotFound("No popular movies found");
                }
            }
            catch (Exception ex)
            {
                // Manage error
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
        
    } 
}
