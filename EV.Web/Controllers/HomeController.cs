
using EV.Application.Interfaces.Services;
using EV.Application.Services.Times.Commands.AddTimes;
using EV.Common.Utilities;
using EV.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;

namespace EV.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntekhabVahedServices _services;

        public HomeController(IEntekhabVahedServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult SetTimes(int timesCount)
        {

            ViewBag.timesCount = timesCount;
            
            return View();
        }

        [HttpPost]
        public IActionResult SetTimes(List<ReqAddTimeService> request)
        {
            var res = _services.TimeServices.AddTime.Execute(request);

            if(res.IsSuccess)
            {
                return RedirectToAction();
            }

			return Json(res);
        }

        


     
    }
}
