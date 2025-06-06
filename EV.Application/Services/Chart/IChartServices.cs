

using EV.Application.Interfaces.Context;
using EV.Application.Services.Chart.Commands.SetCharst;
using EV.Application.Services.Chart.Queries.GetChartDetails;
using EV.Application.Services.Chart.Queries.GetCharts;
using EV.Application.Services.Times;

namespace EV.Application.Services.Chart
{
	public interface IChartServices
	{
		ISetChartsService SetCharts { get; }
		IGetChartsService GetCharts { get; }
		IGetChartDatilsService GetChartDatils { get; }
	}

	public class ChartServices : IChartServices
	{
		private readonly IDataBaseContext _context;
		public ChartServices(IDataBaseContext context)
		{
			_context = context;
		}

		private ISetChartsService _setCharts;
		public ISetChartsService SetCharts
		{
			get
			{
				return _setCharts = _setCharts ?? new SetChartsService(_context);
			}
		}

		private IGetChartsService _getCharts;
		public IGetChartsService GetCharts
		{
			get
			{
				return  _getCharts = _getCharts ?? new GetChartsService(_context);
			}
		}

		private IGetChartDatilsService _getChartDatils;
		public IGetChartDatilsService GetChartDatils
		{
			get
			{
				return _getChartDatils = _getChartDatils ?? new GetChartDetailsService(_context);
			}
		}
	}
}
