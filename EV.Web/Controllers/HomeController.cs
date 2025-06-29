
using EV.Application.Interfaces.Services;
using EV.Application.Services.Chart.Commands.SetCharst;
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
        public IActionResult SetTimes()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult SetTimes(ReqAddTimeService request)
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
                return RedirectToAction("CalculateEV");
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
            return Json(null);
        }

        public IActionResult CalculateEV ()
        {
            var result = _services.CalculatorServices.CalculateEV.Execute();

            ReqSetChartDto request = new ReqSetChartDto();
            request.Charts = new List<ChartsItem>();

            foreach (var item in result.Data.acceptedArrenge)
            {
                request.Charts.Add(new ChartsItem()
                {
                    LessonGroupsId = item.Select(i => i.GruopId).ToList()
                });
            }

            _services.ChartServices.SetCharts.Execute(request);

            return RedirectToAction("Charts");
        }

        public IActionResult Charts()
        {
            return View(_services.ChartServices.GetCharts.Execute());
        }

        public IActionResult ChartDetails (Guid ChartId)
        {
            ViewBag.Times = _services.TimeServices.GetTimes.Execute().Data;
            return View(_services.ChartServices.GetChartDatils.Execute(ChartId));
        }

        


     
    }
}
