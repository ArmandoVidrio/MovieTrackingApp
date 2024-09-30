using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MovieTrackingAPP.Controllers;
using MovieTrackingAPP.Interfaces;
using MovieTrackingAPP.Models;
using MovieTrackingAPP.Services;
using Newtonsoft.Json;


namespace MovieTrackingAPP.Tests;

public class MovieControllerTests
{

    [Fact]
    public async Task GetPopularMovies_ReturnsOkResult_WithListOfMovies()
    {
        // Arrange: Create a list of movies
        var mockMovies = new List<Movie>
        {
            new Movie { Title = "Movie 1", Rating = 8.5 },
            new Movie { Title = "Movie 2", Rating = 7.3 }
        };
        
        // We create a mock of the MovieService
        var mockMovieService = new Mock<IMovieService>();
        
        // Inyect the simulated service into the controller
        var controller = new MoviesController(mockMovieService.Object);
        
        // Act
        var result = await controller.GetPopularMoviesAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);

        // Access the value from the result
        var returnValue = Assert.IsAssignableFrom<List<Movie>>(okResult.Value);

        // Print the content of the response
        var jsonString = JsonConvert.SerializeObject(returnValue, Formatting.Indented);
        Console.WriteLine("Returned Movies: " + jsonString);

        Assert.NotEmpty(returnValue);

    }
}