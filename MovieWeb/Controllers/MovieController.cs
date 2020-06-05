using Microsoft.AspNetCore.Mvc;
using MovieWeb.Models;
using System;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Detail()
        {
            MovieDetailViewModel lionKing = new MovieDetailViewModel()
            {
                Title = "Lion King",
                Description = "Best movie ever",
                Genre = "Test",
                ReleaseDate = new DateTime(1994, 5, 4)
            };

            return View(lionKing);
        }
    }
}
