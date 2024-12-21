using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Repositories;

namespace tp4.Infrastructure.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetMoviesWithGenres()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Movies.Include(m => m.Genre).Where(m => m.GenreId == genreId).ToList();
        }

        public void AddReview(Review review)
        {
            _context.Set<Review>().Add(review);
            _context.SaveChanges();
        }
    }
}
