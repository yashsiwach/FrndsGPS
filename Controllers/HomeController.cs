using Microsoft.AspNetCore.Mvc;
using NearbyFriendsApp.Models;
using NearbyFriendsApp.Services;
using System.Diagnostics;

namespace NearbyFriendsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocationService service;

        public HomeController(LocationService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveLocation([FromBody] UserLocation location)
        {
            if (location == null)
                return BadRequest();

            service.SaveLocation(location);

            return Ok(new { success = true });
        }
        [HttpGet]
        public IActionResult GetLocations()
        {
            var data = service.GetAll();
            return Json(data);
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
