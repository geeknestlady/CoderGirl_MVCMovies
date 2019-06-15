using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingListViewModel
    {
        public static List<MovieRatingListViewModel> GetMovieRatingList()
        {
            return RepositoryFactory.GetMovieRatingRepository()
                .GetModels()
                .Cast<MovieRating>()
                .Select(rating => GetRatingFromMovie(rating))
                .ToList();
        }

        private static MovieRatingListViewModel GetRatingFromMovie(MovieRating rating)
        {
            return new MovieRatingListViewModel
            {
                Id = rating.Id,
                MovieName = rating.MovieName,
                Rating = rating.Rating,
                MovieId = rating.MovieId,              
            };
        }

        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
