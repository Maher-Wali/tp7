public class Review
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}
