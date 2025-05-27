using EV.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EV.Web.Controllers
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

        [HttpGet]
        public IActionResult SetTimes(int timesCount)
        {
            ViewBag.TimesCount = timesCount;
            return View();
        }

        [HttpPost]
        public IActionResult SetTimes(TimeOnly time)
        {

            return Json(1);
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
