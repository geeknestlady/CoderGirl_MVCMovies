﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            List<MovieRating> movieRatings = ratingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MovieNames = movieRepository.GetMovies().Select(movie => movie.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            ratingRepository.Save(movieRating);
            return RedirectToAction(actionName: nameof(Index));
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
        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }
    }
}