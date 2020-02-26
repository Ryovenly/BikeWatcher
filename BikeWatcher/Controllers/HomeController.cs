using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeWatcher.Models;

namespace BikeWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> StationsAsync()
        {
            var Stations = await StationService.FindStations();
            ViewBag.AllStation = Stations;

            return View();
        }
        public async Task<IActionResult> MapAsync()
        {
            var Stations = await StationService.FindStations();
            ViewBag.AllStation = Stations;

            var cardsBdx = await StationService.StationBdx();

            var ResultBdx = new List<Stations>();
            foreach (var stationBdx in cardsBdx)
            {
                var construit = new Stations(stationBdx);
                ResultBdx.Add(construit);
            }

            Stations.AddRange(ResultBdx);
            return View();
        }
        public IActionResult Favorites()
        {
            return View();
        }
        public IActionResult Prevent()
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
