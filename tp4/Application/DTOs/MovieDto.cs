namespace tp4.Application.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public string PhotoPath { get; set; }
    }
}
