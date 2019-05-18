﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            List<MovieRating> movieRatings = ratingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MovieNames = movieRepository.GetMovies().Select(m => m.Name).ToList();
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(MovieRating movieRating)
        //{

        //   // Movie movie = movieRepository.GetById(movieRating.Id);
        //   // movieRating.MovieId = movie.Id;
        //    ratingRepository.Save(movieRating);
        //    return RedirectToAction(actionName: nameof(Index));
        //}
        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            var movie = movieRepository.GetMovies().FirstOrDefault(x => x.Name == movieRating.MovieName);
            if (movie.Id != movieRating.MovieId)
            {
                movieRating.MovieId = movie.Id;
            }
            ratingRepository.Save(movieRating);
            return RedirectToAction("Index","Movie");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = ratingRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            ratingRepository.Update(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ratingRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}