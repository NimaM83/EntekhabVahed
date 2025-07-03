using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Times.Queries.GetTimes
{
	public class GetTimesServiec : IGetTimesService
	{
		private readonly IDataBaseContext _context;
		public GetTimesServiec(IDataBaseContext context)
		{
			_context = context;
		}

		public Result<ResGetTimes> Execute(Guid EVId)
		{
			try
			{
				var foundedTimes = _context.Times.Where(t => t.EVId.Equals(EVId)).ToList();
				if (foundedTimes.Any())
				{
					foundedTimes = SortTimes(foundedTimes);
					var times = new ResGetTimes();
					times.Times = new List<GetTimesItem>();

                    foreach (var item in foundedTimes)
                    {
						times.Times.Add(new GetTimesItem()
						{
							Id = item.Id,
							From = item.From.ToString("HH:mm"),
							To = item.To.ToString("HH:mm")
						});
                    }

					return new Result<ResGetTimes>()
					{
						IsSuccess = true,
						Message = "مقادیر یافت شدند",
						Data = times
					};
                }

				return new Result<ResGetTimes>()
				{
					IsSuccess = false,
					Message = "متاسفانه بازه ساعتی ای پیدا نشد"
				};
			}
			catch (Exception ex)
			{
				return new Result<ResGetTimes>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}

		private List<Time> SortTimes (List<Time> times)
		{
			Time min = new Time();
			Time temp = new Time();
			for(int i = 0; i < times.Count; i++)
			{
				min = times[i];
				for(int j = 0; j < times.Count; j++)
				{
					if (times[i].From < min.From)
					{
						temp = min;
						min = times[i];
						times[i] = temp;
					}
				}
			}

			return times;
		}
	}
}
