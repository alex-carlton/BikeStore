using BikeStore.Service.Interfaces;
using BikeStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BikeStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDateTimeService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var localTime = _service.Now;

            if (localTime.Hour < 12)
            {
                ViewData["Message"] = "Good Morning!";
            }
            else if (localTime.Hour < 17)
            {
                ViewData["Message"] = "Good Afternoon!";
            }
            else
            {
                ViewData["Message"] = "Good Evening!";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}