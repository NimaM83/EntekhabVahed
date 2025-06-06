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

		public Result Execute (ReqSetChartDto request)
		{
			try
			{
				foreach(var item in request.Charts)
				{
					foreach(var inerItem in item.LessonGroupsId)
					{
						if(_context.LessonGroups.Find(inerItem) == null)
						{
							return new Result()
							{
								IsSuccess = false,
								Message = "یکی از گروه های درسی یافت نشد"
							};
						}
					}
				}

				foreach(var item in request.Charts)
				{
					var chart = new Domain.Entities.Chart.Chart();
					chart.LessonGroupsId = item.LessonGroupsId;
					_context.Charts.Add(chart);
				}
				_context.SaveChanges();

				return new Result()
				{
					IsSuccess = true,
					Message = "جدول ها با موفقیت ساخته شدند"
				};


			} catch(Exception ex)
			{
				return new Result()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}
		
}
