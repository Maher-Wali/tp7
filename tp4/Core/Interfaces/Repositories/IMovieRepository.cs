using System.Collections.Generic;
using tp4.Core.Entities;

namespace tp4.Core.Interfaces.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IEnumerable<Movie> GetMoviesWithGenres();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        void AddReview(Review review);
    }
}
