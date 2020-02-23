using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sightings.Models;

namespace Sightings.Controllers
{
    public class HomeController : Controller
    {
        private Irepository repository { get; set; }

        public HomeController(Irepository repo) => repository = repo;

        public ViewResult Index() => View(repository.Sightings);

        [HttpPost]
        public IActionResult AddSighting(Sighting sighting)
        {
            repository.AddSighting(sighting);
            return RedirectToAction("Index");
        }



        //Below is pregenerated code

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
