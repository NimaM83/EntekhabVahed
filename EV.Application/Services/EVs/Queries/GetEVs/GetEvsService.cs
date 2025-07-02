using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.EV;

namespace EV.Application.Services.EVs.Queries.GetEVs
{
	public class GetEvsService : IGetEVsService
	{
		private readonly IDataBaseContext _dbContext;
		public GetEvsService(IDataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Result<ResGetEvsDto> Execute ()
		{
			try
			{
				var foundedEVs = _dbContext.EVs.ToList();

				if(foundedEVs.Any())
				{
					var evs = new List<ItemGetEvsDto>();

					foreach(var item in foundedEVs)
					{
						evs.Add(new ItemGetEvsDto()
						{
							Id = item.Id,
							Title = item.Title,
							State = item.State,
							StateStr = (item.State.Equals(EVState.Finished)) ? "تکمیل شده" : "تکمیل نشده"
						});
					}

					var result = new ResGetEvsDto();
					result.EVs = evs;

					return new Result<ResGetEvsDto>()
					{
						IsSuccess = true,
						Message = "انتخاب واحد ها با موفقیت یافت شدند",
						Data = result
					};

				}

				return new Result<ResGetEvsDto>()
				{
					IsSuccess = false,
					Message = "انتخاب واحدی یافت نشد"
				};

			} catch(Exception ex)
			{
				return new Result<ResGetEvsDto>()
				{
					IsSuccess = false,
					Message = "خطای نا مشخصی رخ داد"
				};

			}
		}


	}
}
