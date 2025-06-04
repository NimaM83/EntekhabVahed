

using EV.Application.Interfaces.Context;
using EV.Application.Services.Chart.Commands.SetCharst;

namespace EV.Application.Services.Chart
{
	public interface IChartServices
	{
		ISetChartsService SetCharts { get; }
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
	}
}
