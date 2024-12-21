using tp4.Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    // Add these for reviews and ratings
    public ICollection<Review> Reviews { get; set; }
    public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0.0;
}
