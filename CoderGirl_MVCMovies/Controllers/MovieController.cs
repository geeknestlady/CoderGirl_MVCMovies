﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetMovies();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepository.Save(movie);
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetByID(id);
            return View("Create", movie);
        }
        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}