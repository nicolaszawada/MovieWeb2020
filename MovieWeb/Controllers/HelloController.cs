using Microsoft.AspNetCore.Mvc;
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

        public HelloController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Welcome(string name = "Vreemdeling", int numberOfTimes = 1)
        {
            _messageService.Send("Iemand bezoekt de welcome pagina");
            ViewData["Name"] = name;
            ViewData["NumberOfTimes"] = numberOfTimes;
            return View();
        }
    }
}
