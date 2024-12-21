using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.Movies
{
    public class GetAllMovies
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMovies(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> ExecuteAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            return movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                GenreId = m.GenreId
            });
        }
    }
}
