namespace MovieTrackingAPP.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Rating { get; set; }

    public Movie()
    {
        
    }
    
    public Movie(string title, double rating)
    {
        this.Title = title;
        this.Rating = rating;
    }
}