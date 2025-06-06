using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;


namespace EV.Application.Services.Chart.Queries.GetCharts
{
	public class GetChartsService : IGetChartsService
	{
		private readonly IDataBaseContext _context;
		public GetChartsService(IDataBaseContext context)
		{
			_context = context;
		}

		public Result<ResGetChartsDto> Execute()
		{
			try
			{
				List<Guid> Charts = _context.Charts.Select(c => c.Id).ToList();

				if(Charts.Any())
				{
					return new Result<ResGetChartsDto>()
					{
						IsSuccess = true,
						Message = "لیست جداول دریافت شد",
						Data = new ResGetChartsDto()
						{
							Charts = Charts
						}
					};
				}

				return new Result<ResGetChartsDto>()
				{
					IsSuccess = false,
					Message = "جدولی یافت نشد، ظاهرا با دروسی ک وارد کردید انتخاب واحد مجازی وجود نداره"
				};
			}
			catch (Exception ex)
			{
				return new Result<ResGetChartsDto>()
				{
					IsSuccess = false,
					Message = "خطای نا مشخصی رخ داد"
				};
			}
		}
	}

}
