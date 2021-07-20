using BikeStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BikeStore.WebApp.Controllers
{
    public class BikeStoreController : Controller
    {
        private readonly IBikeService _service;
        private readonly ILogger<BikeStoreController> _logger;

        public BikeStoreController(ILogger<BikeStoreController> logger, IBikeService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var bikeData = _service.GetBike(1234);

            ViewData["Category"] = bikeData.Category;
            ViewData["Name"] = bikeData.Name;
            ViewData["Price"] = bikeData.Price;
            ViewData["SerialNumber"] = bikeData.SerialNumber;

            return View();
        }
    }
}