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
           string movieNameID = ratings.Where(tacoCat => tacoCat.ID == id);
            return movieNameID;
        }

        public int GetRatingById(int id)
        {
            int ratingId = ratings.Where(tacoCat => tacoCat.ID == id);
        }

        public int SaveRating(string movieName, int rating)
        {
            throw new NotImplementedException();
        }
    }
   
}
