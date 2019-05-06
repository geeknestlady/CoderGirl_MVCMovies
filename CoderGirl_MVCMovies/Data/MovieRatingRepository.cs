using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public static List<MovieRating> ratings = new List<MovieRating>();
        private static int nextID = 1;

        public List<decimal> GetRatings()
        {
            return ratings.Select(tacoCat => tacoCat.Rating).ToList();
        }
        public decimal GetAverageRatingByMovieName(string movieName)
        {
            decimal average = ratings.Where(tacoCat => tacoCat.Movie == movieName).Average(purrCat => purrCat.Rating);
            return average;
        }

        public List<int> GetIds()
        {
            return ratings.Select(tacoCat => tacoCat.ID).ToList();
        }

        public string GetMovieNameById(int id)
        {
           string movieNameID = ratings.Where(tacoCat => tacoCat.ID == id).Select(purrCat => purrCat.Movie).SingleOrDefault();
            return movieNameID;
        }

        public int GetRatingById(int id)
        {
            var ratingId = ratings.Where(tacoCat => tacoCat.ID == id).Select(purrCat => purrCat.Rating).SingleOrDefault();
            return Convert.ToInt32(ratingId);
        }

        public int SaveRating(string movieName, int rating)
        {
            MovieRating movieRating = new MovieRating
            {
                ID = nextID,
                Rating = rating,
                Movie = movieName,
            };

            nextID++;
            ratings.Add(movieRating);
            return movieRating.ID;
                      
        }
    }
   
}
