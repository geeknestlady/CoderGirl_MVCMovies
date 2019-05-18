﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;


namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        static List<MovieRating> movieRatings = new List<MovieRating>();
        private static int nextId = 1;

        public void Delete(int id)
        {
            movieRatings.RemoveAll(rating => rating.Id == id);
        }

        public MovieRating GetById(int id)
        {
            return movieRatings.SingleOrDefault(rating => rating.Id == id);
        }

        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        public int Save(MovieRating movieRating)
        {
            movieRating.Id = nextId++;
            movieRatings.Add(movieRating);
            return movieRating.Id;

        }

        public void Update(MovieRating movieRating)
        {
            this.Delete(movieRating.Id);
            movieRatings.Add(movieRating);
        }
    }
}
