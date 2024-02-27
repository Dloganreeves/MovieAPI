using Microsoft.AspNetCore.Mvc;
using OMDB.Models;
using System.Diagnostics;

namespace OMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string movie)
        {
            MovieModel m = MovieDAL.GetMovies(movie);
            return View(m);
        }

        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            MovieModel m1 = MovieDAL.GetMovies(title1);
            MovieModel m2 = MovieDAL.GetMovies(title2);
            MovieModel m3 = MovieDAL.GetMovies(title3);
            List<MovieModel> movies = new List<MovieModel>() {m1,m2,m3};
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
