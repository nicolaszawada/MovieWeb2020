using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Models;
using System;
using System.Collections.Generic;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase _movieDatabase;

        public MovieController(IMovieDatabase movieDatabase)
        {
            _movieDatabase = movieDatabase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> moviesFromDb = _movieDatabase.GetMovies();
            List<MovieListViewModel> movies = new List<MovieListViewModel>();

            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { Id = movie.Id, Title = movie.Title });
            }

            return View(movies);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);

            MovieDetailViewModel movie = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre
            };

            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieCreateViewModel vm = new MovieCreateViewModel();
            vm.ReleaseDate = DateTime.Now;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }

            Movie newMovie = new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre
            };

            _movieDatabase.Insert(newMovie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);

            MovieEditViewModel vm = new MovieEditViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Movie domainMovie = new Movie()
            {
                Id = id,
                Title = vm.Title,
                Description = vm.Description,
                Genre = vm.Genre,
                ReleaseDate = vm.ReleaseDate
            };

            _movieDatabase.Update(id, domainMovie);

            return RedirectToAction("Detail", new { Id = id });
        }

        public IActionResult Delete(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);

            return View(new MovieDeleteViewModel() { Id = movieFromDb.Id, Title = movieFromDb.Title });
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _movieDatabase.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
