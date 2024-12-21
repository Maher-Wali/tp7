namespace tp4.Core.Entities
{
    public class Genre
    {
        public string Name { get; set; }
        public int id { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
