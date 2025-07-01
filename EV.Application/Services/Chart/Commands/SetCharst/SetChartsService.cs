using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;

namespace EV.Application.Services.Chart.Commands.SetCharst
{
	public class SetChartsService : ISetChartsService
	{
		private readonly IDataBaseContext _context;
		public SetChartsService (IDataBaseContext context)
		{
			_context = context;
		}

		public Result<Guid> Execute (ReqSetChartDto request)
		{
			try
			{
				foreach(var item in request.Charts)
				{
					foreach(var inerItem in item.LessonGroupsId)
					{
						if(_context.LessonGroups.Find(inerItem) == null)
						{
							return new Result<Guid>()
							{
								IsSuccess = false,
								Message = "یکی از گروه های درسی یافت نشد"
							};
						}
					}
				}

				var ev = new Domain.Entities.EV.EV();
				_context.EVs.Add(ev);
				_context.SaveChanges();

				foreach (var item in request.Charts)
				{
					var chart = new Domain.Entities.Chart.Chart();
					chart.LessonGroupsId = item.LessonGroupsId;

					chart.EVId = ev.Id;
					_context.Charts.Add(chart);
				}
				_context.SaveChanges();

				return new Result<Guid>()
				{
					IsSuccess = true,
					Message = "جدول ها با موفقیت ساخته شدند"
				};


			} catch(Exception ex)
			{
				return new Result<Guid>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}
		
}
