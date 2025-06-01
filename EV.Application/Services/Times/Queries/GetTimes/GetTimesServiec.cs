using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;

namespace EV.Application.Services.Times.Queries.GetTimes
{
	public class GetTimesServiec : IGetTimesService
	{
		private readonly IDataBaseContext _context;
		public GetTimesServiec(IDataBaseContext context)
		{
			_context = context;
		}

		public Result<ResGetTimes> Execute()
		{
			try
			{
				var foundedTimes = _context.Times.ToList();
				if (foundedTimes.Any())
				{
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
	}
}
