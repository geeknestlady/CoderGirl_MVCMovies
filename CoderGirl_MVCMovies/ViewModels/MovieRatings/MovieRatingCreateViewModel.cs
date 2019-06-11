using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingCreateViewModel
    {        
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }

        public void Persist()
        {
            MovieRating rating = new MovieRating
            {
                MovieName = this.MovieName,
                Rating = this.Rating,
                MovieId = this.MovieId,                
            };
            RepositoryFactory.GetMovieRatingRepository().Save(rating);
        }
    }
}
