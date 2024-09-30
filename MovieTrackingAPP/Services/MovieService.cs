using System.Net;
using System.Text.Json;
using MovieTrackingAPP.Interfaces;
using MovieTrackingAPP.Models;
using RestSharp;

namespace MovieTrackingAPP.Services;

// Service to retrieve the information from the API
public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    
    // Constructor
    public MovieService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["TMBDB_API_KEY"];
    }

    public async Task<List<Movie>> GetPopularMovies()
    {   
        var client = new RestClient("https://api.themoviedb.org/3/authentication");
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_apiKey}");
        
        var response = await client.GetAsync(request);
        
        // Ensure the response its correct
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var movies = JsonSerializer.Deserialize<List<Movie>>(response.Content);
            return movies;
        }
        else
        {
            throw new ApplicationException("An error occured while retrieving movies");
        }
        
    }
    
}

