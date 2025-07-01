using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;

namespace EV.Application.Services.EVs.Queries.GetChartsListCount
{
	public class GetEVsCountService : IGetEVsCountService
	{
		private readonly IDataBaseContext _dbContex;

		public GetEVsCountService(IDataBaseContext dbContex)
		{
			_dbContex = dbContex;
		}

		public Result<int> Execute()
		{
			try
			{
				var result = _dbContex.Charts.Count();

				return new Result<int>()
				{
					IsSuccess = true,
					Data = result,
					Message = "تعداد انتخاب واحد های شما دریافت شد"
				};
			} catch (Exception ex)
			{
				return new Result<int>()
				{
					IsSuccess = false,
					Message = "خطای نا مشخصی رخ داد"
				};
			}
		}
	}
}
