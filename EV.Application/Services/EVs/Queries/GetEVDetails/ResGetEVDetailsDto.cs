using EV.Application.Services.Chart.Queries.GetCharts;

namespace EV.Application.Services.EVs.Queries.GetEVDetails
{
	public class ResGetEVDetailsDto
	{
		public string Title { get; set; }
		public int Number { get; set; }
		public bool IsFinished { get; set; }
		public ResGetChartsDto ChartsResult { get; set; }
	}
}
