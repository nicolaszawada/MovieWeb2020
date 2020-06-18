using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieWeb.Models;
using MovieWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Controllers
{
    public class HelloController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public HelloController(IMessageService messageService, IConfiguration configuration)
        {
            _messageService = messageService;
            _configuration = configuration;
        }

        public IActionResult Welcome(string name = "Vreemdeling", int numberOfTimes = 1)
        {
            _messageService.Send("Iemand bezoekt de welcome pagina");
            ViewData["Name"] = name;
            ViewData["NumberOfTimes"] = numberOfTimes;
            return View();
        }

        public IActionResult Developer()
        {
            DeveloperDetailViewModel vm = new DeveloperDetailViewModel()
            {
                FirstName = _configuration["Developer:FirstName"],
                LastName = _configuration["Developer:LastName"]
            };

            return View(vm);
        }
    }
}
