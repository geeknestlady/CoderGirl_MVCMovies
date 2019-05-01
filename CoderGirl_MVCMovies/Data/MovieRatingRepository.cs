using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public decimal GetAverageRatingByMovieName(string movieName)
        {
            decimal average = 
        }

        public List<int> GetIds()
        {
            throw new NotImplementedException();
        }

        public string GetMovieNameById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetRatingById(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveRating(string movieName, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
