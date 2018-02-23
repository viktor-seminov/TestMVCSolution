using System.Collections.Generic;
using System.Web.Mvc;
using TestMVCSolution.Models;
using TestMVCSolution.ViewModels;


namespace TestMVCSolution.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies { Id = 1, MovieName = "Shrek" },
                new Movies { Id = 2, MovieName = "Wall-e" }
            };
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
    }
}