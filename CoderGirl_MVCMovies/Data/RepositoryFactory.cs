using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public static class RepositoryFactory
    {
        private static IMovieRatingRepository MovieRatingRepository;

        public static IMovieRatingRepository GetMovieRatingRepository()
        {
            if (MovieRatingRepository == null)
            MovieRatingRepository = new MovieRatingRepository();
            return MovieRatingRepository;
        }
    }
}
