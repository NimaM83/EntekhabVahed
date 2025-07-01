using EV.Domain.Entities.Common;


namespace EV.Application.Services.Chart.Queries.GetCharts
{
	public interface IGetChartsService
	{
		Result<ResGetChartsDto> Execute(Guid EVId);
	}

}
