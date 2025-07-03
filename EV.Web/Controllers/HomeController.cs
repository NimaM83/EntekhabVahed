
using EV.Application.Interfaces.Services;
using EV.Application.Services.Chart.Commands.SetCharst;
using EV.Application.Services.Lessons.Commands.AddLesson;
using EV.Application.Services.Times.Commands.AddTimes;
using EV.Common.Utilities;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.EV;
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
            return View(_services.EVsServices.GetEVs.Execute());
        }

        [HttpGet]
        public IActionResult SetTimes(string? EVTitle)
        {
            if(EVTitle is not null)
            {
				string EVId = _services.EVsServices.AddEV.Execute(EVTitle).Data.ToString();

				CookiesManager.Remove(HttpContext, "ActiveEVId");
				CookiesManager.Add(HttpContext, "ActiveEVId", EVId, 1);
			}

            return View();
        }

        [HttpPost]
        public IActionResult SetTimes(ReqAddTimeService request)
        {
            request.EVId = Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"));
            var res = _services.TimeServices.AddTime.Execute(request);

            if(res.IsSuccess)
            {
                _services.EVsServices.ChangeEVState.Execute(request.EVId, Domain.Entities.EV.EVState.SetLessons);
                return RedirectToAction("SetLesson");
            }

			return Json(res);
        }

        [HttpGet]
        public IActionResult SetLesson()
        {
            var resT = _services.TimeServices.GetTimes.Execute(Guid.Parse(CookiesManager.GetValue(HttpContext,"ActiveEVId")));
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
            request.EVId = Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"));
            var res = _services.LessonServices.AddLesson.Execute(request);

            if (res.IsSuccess)
            {
                _services.EVsServices.ChangeEVState.Execute
                    (
                        Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId")),
                        EVState.Finished
                    );
                return RedirectToAction("CalculateEV");
            }

            return Json(res);
        }

        public IActionResult AddLesson(ReqAddLessonDto request)
        {
			request.EVId = Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"));
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
            var result = _services.CalculatorServices.CalculateEV.Execute
                (
                    Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"))
                );

            ReqSetChartDto request = new ReqSetChartDto();
            request.Charts = new List<ChartsItem>();
            request.EVId = Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"));

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

        public IActionResult Charts(Guid? EVId)
        {
            Guid temp = new Guid();

            if(EVId is not null)
            {
                temp = Guid.Parse(EVId.ToString());

                CookiesManager.Remove(HttpContext, "ActivrEVId");
                CookiesManager.Add(HttpContext, "ActiveEVId",temp.ToString() , 1);
			}
            else
            {
                temp = Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"));
			}

            return View(_services.ChartServices.GetCharts.Execute(temp));
                
        }

        public IActionResult ChartDetails (Guid ChartId)
        {
            ViewBag.Times = _services.TimeServices.GetTimes.Execute
                (
					Guid.Parse(CookiesManager.GetValue(HttpContext, "ActiveEVId"))
				).Data;

            return View(_services.ChartServices.GetChartDatils.Execute(ChartId));
        }

        public IActionResult CompletEV (Guid EVId, EVState state)
        {
            CookiesManager.Remove(HttpContext, "ActiveEVId");
            CookiesManager.Add(HttpContext, "ActiveEVId", EVId.ToString(), 1);

            switch(state)
            {
                case EVState.SetTime:
                    return RedirectToAction("SetTimes");

                case EVState.SetLessons:
                    return RedirectToAction("SetLesson");

                default:
                    return BadRequest();
            }
        }

        public IActionResult RemoveEV (Guid EVId)
        {
            var res = _services.EVsServices.RemoveEV.Execute(EVId);

            if(res.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            return Json(res);
        }

        


     
    }
}
