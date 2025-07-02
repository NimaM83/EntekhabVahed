using EV.Application.Interfaces.Context;
using EV.Application.Services.Chart;
using EV.Application.Services.EVs.Commands.AddEV;
using EV.Application.Services.EVs.Queries.GetChartsListCount;
using EV.Application.Services.EVs.Queries.GetEVDetails;
using EV.Application.Services.EVs.Queries.GetEVs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs
{
	public interface IEVsServices
	{
		IGetEVsCountService GetEVsCount { get; }
		IGetEVsService GetEVs { get; }
		IGetEVDetailsService GetEVDetails { get; }
		IAddNewEVService AddEV { get; }
	}

	public class EVsServices : IEVsServices
	{
		private readonly IDataBaseContext _dbContext;
		private readonly IChartServices _chartServices;
		public EVsServices (IDataBaseContext dbContext, IChartServices chartServices)
		{
			_dbContext = dbContext;
			_chartServices = chartServices;
		}

		private IGetEVsCountService _getEVsCount;
		public IGetEVsCountService GetEVsCount
		{
			get
			{
				return _getEVsCount = _getEVsCount ?? new GetEVsCountService(_dbContext);
			}
		}

		private IGetEVsService _getEVs;
		public IGetEVsService GetEVs
		{
			get
			{
				return _getEVs = _getEVs ?? new GetEvsService(_dbContext);
			}
		}

		private IGetEVDetailsService _getEVDetails;
		public IGetEVDetailsService GetEVDetails
		{
			get
			{
				return _getEVDetails = _getEVDetails ?? new GetEVDetailsService(_chartServices,_dbContext);
			}
		}

		private IAddNewEVService _addEV;
		public IAddNewEVService AddEV
		{
			get
			{
				return _addEV = _addEV ?? new AddNewEVService(_dbContext);
			}
		}

	}
}
