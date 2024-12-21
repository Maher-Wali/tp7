using tp4.Core.Entities;

namespace tp4.Core.Interfaces.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        IEnumerable<Movie> GetMoviesWithGenres();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        void AddReview(Review review);
    }
}
