using EV.Application.Interfaces.Context;
using EV.Application.Services.Chart;
using EV.Domain.Entities.Common;

namespace EV.Application.Services.EVs.Queries.GetEVDetails
{
	public class GetEVDetailsService : IGetEVDetailsService
	{
		private readonly IChartServices _chartContext;
		private readonly IDataBaseContext _dbContext;
		public GetEVDetailsService(IChartServices chartContext, IDataBaseContext dbContext)
		{
			_chartContext = chartContext;
			_dbContext = dbContext;
		}

		public Result<ResGetEVDetailsDto> Execute(Guid EVId)
		{
			try
			{
				var charts = _chartContext.GetCharts.Execute(EVId);
				
				if(charts.IsSuccess)
				{
					var ev = _dbContext.EVs.Find(EVId);

					if(ev != null)
					{
						return new Result<ResGetEVDetailsDto>()
						{
							IsSuccess = true,
							Message = charts.Message,
							Data = new ResGetEVDetailsDto()
							{
								ChartsResult = charts.Data,
								Title = ev.Title,
								State = ev.State
							}
						};
					}
				}

				return new Result<ResGetEVDetailsDto>()
				{
					IsSuccess = false,
					Message = charts.Message
				};

			} catch(Exception ex)
			{
				return new Result<ResGetEVDetailsDto>
				{
					IsSuccess = false,
					Message = "خطای نا مشحصی رخ داد"
				};
			}
		}
	}
}
