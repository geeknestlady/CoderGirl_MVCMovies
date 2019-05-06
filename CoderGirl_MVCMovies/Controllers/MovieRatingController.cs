using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();

        
        public static List<Movie> movies = Controllers.MovieController.movies;
        public static Movie movie = new Movie();

        private string htmlForm = @"
            <form method='post'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>                    
                </select>
                <button type='submit'>Rate it</button>
            </form>";

       
        
        /// TODO: Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {

            //List<int> getIDs = repository.GetIds();
            
            //Dictionary<string, int> ids = new Dictionary<string, int>();

            //foreach (int id in getIDs)
            //{
            //    string name = repository.GetMovieNameById();
            //    int rating = repository.GetRatingById();
            //    ids.Add(name, rating);
            //}

            //ViewBag.Movies = getIDs;
            return View();
        }

        // TODO: Create a view MovieRating/Create and put the htmlForm there. Remember that html in a view should not be a string.
        // TODO: Change the input tag for movie name to be a drop down which has a list of movies from the movie repository
        // TODO: Change this method to return that view. 
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = MovieController.movies;
            return View();
        }
               

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {

            repository.SaveRating(movieName, Convert.ToInt32(rating));
            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        // TODO: The Details method should take an int parameter which is the id of the movie/rating to display.
        // TODO: Create a Details view which displays the formatted string with movie name and rating in an h2 tag. 
        // TODO: The Details view should include a link to the MovieRating/Index page
        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            
            ViewBag.Name = movieName;
            ViewBag.Rating = rating;
            return View();
        }
    }
}