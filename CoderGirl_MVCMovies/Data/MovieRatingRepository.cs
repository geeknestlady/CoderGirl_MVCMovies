using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public static List<Movie> ratings = new List<Movie>();
        private static int nextID = 1; 

        public decimal GetAverageRatingByMovieName(string movieName)
        {
            decimal average = ratings.Where(tacoCat => tacoCat.Name == movieName).Average(purrCat => purrCat.Rating);
            return average;
        }

        public List<int> GetIds()
        {
            return ratings.Select(tacoCat => tacoCat.ID).ToList();
        }

        public string GetMovieNameById(int id)
        {
           string movieNameID = ratings.Where(tacoCat => tacoCat.ID == id).Select(purrCat => purrCat.Name).SingleOrDefault();
            return movieNameID;
        }

        public int GetRatingById(int id)
        {
            var ratingId = ratings.Where(tacoCat => tacoCat.ID == id).Select(purrCat => purrCat.Rating);
            return Convert.ToInt32(ratingId);
        }

        public int SaveRating(string movieName, int rating)
        {
            Movie movieRating = new Movie
            {
                ID = nextID,
                Rating = rating,
                Name = movieName,
            };

            nextID++;
            ratings.Add(movieRating);
            return movieRating.ID;
                      
        }
    }
   
}
