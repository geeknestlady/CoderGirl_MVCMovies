using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
       // public static Dictionary<int, string> movies = new Dictionary<int, string>();
        public static List<Movie> movies = new List<Movie>();
        private static int nextIdToUse = 1; 

        public IActionResult Index()
        {
            ViewBag.Movies = movies;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movie)
        {
            Movie movieName = new Movie
            {
                ID = nextIdToUse,
                MoviesName = movie,
            };
            nextIdToUse++;
            
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}