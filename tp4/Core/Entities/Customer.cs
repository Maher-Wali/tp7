using tp4.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public int MembershipTypeId { get; set; }
    public MembershipType membershiptype { get; set; }

    // Add this for favorite films
    public ICollection<Movie> FavoriteMovies { get; set; }
}
