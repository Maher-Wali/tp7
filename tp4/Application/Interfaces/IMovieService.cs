using tp4.Core.Entities;

namespace tp4.Services.MovieService
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetMoviesByGenre(string genreName);
        public IEnumerable<Movie> GetAllMoviesOrdered();
        public IEnumerable<Movie> GetMoviesByGenreId(int genreId);
        IEnumerable<Movie> GetAllMovies();
        Movie GetById(int id);
        IEnumerable<Movie> GetMoviesWithGenre();
        void Add(Movie m);
        void Update(Movie m);
        void Delete(int id);
        IEnumerable<Genre> GetGenre();
    }
}
