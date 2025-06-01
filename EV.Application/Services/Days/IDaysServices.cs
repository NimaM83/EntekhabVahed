using EV.Application.Services.Days.Queries.GetDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Days
{
	public interface IDaysServices
	{
		IGetDaysService GetDays {  get; }
	}

	public class DaysServices : IDaysServices
	{
		private IGetDaysService _getDays;
		public IGetDaysService GetDays
		{
			get
			{
				return _getDays = _getDays ?? new GetDaysService();
			}
		}
	}
}
