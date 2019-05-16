using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : IMovieRespository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;
        static IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public Movie GetById(int id)
        {
            Movie movie = movies.SingleOrDefault(m => m.Id == id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            return movies.Select(movie => SetMovieRatings(movie)).Select(movie => SetDirectorName(movie)).ToList();
        }

        public int Save(Movie movie)
        {
            movie.Id = nextId++;
            movies.Add(movie);
            return movie.Id;
        }

        public void Update(Movie movie)
        {
            this.Delete(movie.Id);
            movies.Add(movie);
        }

        private Movie SetMovieRatings(Movie movie)
        {
            List<int> ratings = ratingRepository.GetMovieRatings()
                                                .Where(rating => rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList();
            movie.Ratings = ratings;
            return movie;
        }
        private Movie SetDirectorName(Movie movie)
        {
            Director director = directorRepository.GetById(movie.DirectorId);
            movie.DirectorName = director.LastFirst;
            return movie;
        }

        //Created method to Set the movie.AverageRating from ratingRepository
        //private Movie SetAverageRating(Movie movie)
        //{

        //    List<Movie> ratings = SetMovieRatings(movie);
        //    double ratingAverage = SetMovieRatings(movie).Average(rating => rating.Rating);

        //    movie.AverageRating = ratingAverage;
        //    return movie;
        //}
        //Created method to Set the movie.RatingsNumber by counting items in movie.Ratings
        //private Movie SetNumberofRatings(Movie movie)
        //{
        //    int numberOfRatings = movie.Ratings.Count;
        //    movie.RatingsNumber = numberOfRatings;
        //    return movie;
        //}
      
    }
}
