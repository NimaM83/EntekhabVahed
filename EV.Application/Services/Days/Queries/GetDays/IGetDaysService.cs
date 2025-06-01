using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Days.Queries.GetDays
{
	public interface IGetDaysService
	{
		Result<ResGetDaysDto> Execute();
	}

	public class GetDaysService : IGetDaysService
	{
		public Result<ResGetDaysDto> Execute()
		{
			try
			{
				var result = new ResGetDaysDto()
				{
					Days = new List<GetDaysItem>()
					{
						new GetDaysItem()
						{
							Value = 0,
							Day = "شنبه"
						},
						new GetDaysItem()
						{
							Value = 1,
							Day = "یک شنبه"
						},
						new GetDaysItem()
						{
							Value = 2,
							Day = "دو شنبه"
						},
						new GetDaysItem()
						{
							Value = 3,
							Day = "سه شنبه"
						},
						new GetDaysItem()
						{
							Value = 4,
							Day = "چهار شنبه"
						},
						new GetDaysItem()
						{
							Value = 5,
							Day = "پنج شنبه"
						},
					}
				};

				return new Result<ResGetDaysDto>()
				{
					Data = result,
					IsSuccess = true,
					Message = "روز ها با موفقیت دریافت  شدند"
				};
			}
			catch (Exception ex)
			{
				return new Result<ResGetDaysDto>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}

	public class ResGetDaysDto
	{
		public List<GetDaysItem> Days { get; set; }
	}

	public class GetDaysItem
	{
		public int Value { get; set; }
		public string Day { get; set; }
	}
}
