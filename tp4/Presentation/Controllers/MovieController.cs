using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp4.Core.Entities;
using tp4.Application.Services;
using tp4.Core.Interfaces.Services;

namespace tp4.Presentation.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Create()
        {
            PopulateGenres();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.CreateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            PopulateGenres(movie.GenreId);
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            PopulateGenres(movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.UpdateMovie(movie);
                }
                catch (Exception)
                {
                    if (_movieService.GetMovieById(id) == null)
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateGenres(movie.GenreId);
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }

        private void PopulateGenres(int? selectedGenreId = null)
        {
            ViewData["GenreId"] = new SelectList(_movieService.GetMoviesWithGenres(), "Id", "Name", selectedGenreId);
        }

        public IActionResult MoviesByGenre(int genreId)
        {
            var movies = _movieService.GetMoviesByGenre(genreId);
            return View(movies);
        }

        // GET: AddReview
        public IActionResult AddReview(int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            var review = new Review
            {
                MovieId = movieId
            };

            ViewBag.MovieName = movie.Name; // For display purposes
            return View(review);
        }

        // POST: AddReview
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview([Bind("MovieId, CustomerId, Comment, Rating")] Review review)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddReview(review);
                return RedirectToAction("Details", new { id = review.MovieId });
            }

            var movie = _movieService.GetMovieById(review.MovieId);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.MovieName = movie.Name; // Retain movie name for display
            return View(review);
        }
    }
}
