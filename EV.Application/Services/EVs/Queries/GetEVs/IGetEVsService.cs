using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs.Queries.GetEVs
{
	public interface IGetEVsService
	{
		Result<ResGetEvsDto> Execute();	
	}

	public class GetEvsService
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
							Number = item.Number
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

	public class ResGetEvsDto
	{
		public List<ItemGetEvsDto> EVs { get; set; }
	}

	public class ItemGetEvsDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public int Number { get; set; }

	}
}
