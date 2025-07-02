using EV.Application.Services.Chart.Queries.GetCharts;
using EV.Domain.Entities.EV;

namespace EV.Application.Services.EVs.Queries.GetEVDetails
{
	public class ResGetEVDetailsDto
	{
		public string Title { get; set; }
		public EVState State { get; set; }
		public ResGetChartsDto ChartsResult { get; set; }
	}
}
