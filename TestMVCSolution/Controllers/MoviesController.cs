using System.Collections.Generic;
using System.Web.Mvc;
using TestMVCSolution.Models;
using TestMVCSolution.ViewModels;
using System.Data.Entity;
using System.Linq;
using System;

namespace TestMVCSolution.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movies() { MovieName = "Shrek!" };
            var customers = new List<Customers>
            {
                new Customers { CustomerName = "Customer 1" },
                new Customers { CustomerName = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = customers
            };

            return View(viewModel);
        }

       
        public ActionResult New()
        {
            var genres = _context.Genres;
            var viewModel = new MovieGenreViewModel
            {
                Genres = genres,
                Movie = new Movies()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieGenreViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movies movie)
        {

            if (movie.Id != 0)
            {
                var movieAtDb = _context.Movies.Single(s => s.Id == movie.Id);
                movieAtDb.MovieName = movie.MovieName;
                movieAtDb.ReleaseDate = movie.ReleaseDate;
                movieAtDb.NumberInStock = movie.NumberInStock;
            }
            else
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}