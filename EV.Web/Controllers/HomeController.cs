
using EV.Application.Interfaces.Services;
using EV.Application.Services.Lessons.Commands.AddLesson;
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
            if(_services.TimeServices.GetTimes.Execute().IsSuccess)
            {
                return RedirectToAction("SetLesson");
            }
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
                return RedirectToAction("SetLesson");
            }

			return Json(res);
        }

        [HttpGet]
        public IActionResult SetLesson()
        {
            var resT = _services.TimeServices.GetTimes.Execute();
            var resD = _services.DaysServices.GetDays.Execute();

            if (resT.IsSuccess && resD.IsSuccess)
            {
                ViewBag.Times = resT.Data;
                ViewBag.Days = resD.Data;
                return View();
            }

            return Json(resT);
        }

        [HttpPost]
        public IActionResult SetLesson(ReqAddLessonDto request)
        {
            var res = _services.LessonServices.AddLesson.Execute(request);
            if (res.IsSuccess)
            {
                return RedirectToAction();
            }

            return Json(res);
        }

        public IActionResult AddLesson(ReqAddLessonDto request)
        {
            var res = _services.LessonServices.AddLesson.Execute(request);
            if (res.IsSuccess)
            {
                return RedirectToAction("SetLesson");
            }

            return Json(res);


        }

        public IActionResult Check ()
        {
            return Json(_services.CalculatorServices.CalculateEV.Execute());
        }

        


     
    }
}
