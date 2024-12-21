using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Core.Interfaces.Services;

namespace tp4.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _movieRepository.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.Delete(id);
        }

        public IEnumerable<Movie> GetMoviesWithGenres()
        {
            return _movieRepository.GetMoviesWithGenres();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public void AddReview(Review review)
        {
            _movieRepository.AddReview(review);
        }
    }
}
