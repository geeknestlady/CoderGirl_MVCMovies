using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingEditViewModel
    {
        public static MovieRatingEditViewModel GetModel(int id)
        {
            MovieRating rating = (MovieRating)RepositoryFactory.GetMovieRatingRepository().GetById(id);
            return new MovieRatingEditViewModel
            {
                Id = rating.Id,
                MovieName = rating.MovieName,
                Rating = rating.Rating,
                MovieId = rating.MovieId
            };
        }

        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }

        public void Persist(int id)
        {
            MovieRating rating = new MovieRating
            {
                Id = id,
                MovieName = this.MovieName,
                Rating = this.Rating,
                MovieId = this.MovieId,               
            };
            RepositoryFactory.GetDirectorRepository().Update(rating);
        }
    }
}
