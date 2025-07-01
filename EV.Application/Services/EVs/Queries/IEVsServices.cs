using EV.Application.Interfaces.Context;
using EV.Application.Services.EVs.Queries.GetChartsListCount;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs.Queries
{
	public interface IEVsServices
	{
		IGetEVsCountService GetEVsCount { get; }
	}

	public class EVsServices : IEVsServices
	{
		private readonly IDataBaseContext _dbContext;
		public EVsServices (IDataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		private IGetEVsCountService _getEVsCount;
		public IGetEVsCountService GetEVsCount
		{
			get
			{
				return _getEVsCount = _getEVsCount ?? new GetEVsCountService(_dbContext);
			}
		}
	}
}
