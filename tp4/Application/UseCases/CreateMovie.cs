using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.Movies
{
    public class CreateMovie
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovie(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task ExecuteAsync(MovieDto movieDto)
        {
            var movie = new Movie
            {
                Name = movieDto.Name,
                GenreId = movieDto.GenreId,
            };

            await _movieRepository.AddAsync(movie);
        }
    }
}
