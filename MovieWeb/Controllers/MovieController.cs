using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Models;
using MovieWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMessageService _messageService;
        private readonly MovieDbContext _movieDbContext;

        public MovieController(IWebHostEnvironment hostingEnvironment, 
            IMessageService messageService, MovieDbContext movieDbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _messageService = messageService;
            _movieDbContext = movieDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> moviesFromDb = await _movieDbContext.Movies.ToListAsync();

            List<MovieListViewModel> movies = new List<MovieListViewModel>();

            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { Id = movie.Id, Title = movie.Title });
            }

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Movie movieFromDb = await _movieDbContext.Movies.FindAsync(id);

            MovieDetailViewModel movie = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre,
                Photo = movieFromDb.Photo
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateViewModel movie)
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

            if (movie.Photo != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(movie.Photo.FileName);
                var pathName = Path.Combine(_hostingEnvironment.WebRootPath, "pics");
                var fileNameWithPath = Path.Combine(pathName, uniqueFileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    movie.Photo.CopyTo(stream);
                }

                newMovie.Photo = "/pics/" + uniqueFileName;
            }

            _movieDbContext.Movies.Add(newMovie);
            await _movieDbContext.SaveChangesAsync();

            _messageService.Send("Er heeft iemand een film aangemaakt!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Movie movieFromDb = await _movieDbContext.Movies.FindAsync(id);

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
        public async Task<IActionResult> Edit(int id, MovieEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Movie domainMovie = await _movieDbContext.Movies.FindAsync(id);

            domainMovie.Title = vm.Title;
            domainMovie.Description = vm.Description;
            domainMovie.Genre = vm.Genre;
            domainMovie.ReleaseDate = vm.ReleaseDate;

            _movieDbContext.Update(domainMovie);

           await _movieDbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { Id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            Movie movieFromDb = await _movieDbContext.Movies.FindAsync(id);

            return View(new MovieDeleteViewModel() { Id = movieFromDb.Id, Title = movieFromDb.Title });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Movie movieToDelete = await _movieDbContext.Movies.FindAsync(id);
            _movieDbContext.Movies.Remove(movieToDelete);
            await _movieDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
