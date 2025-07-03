using EV.Domain.Entities.Common;


namespace EV.Application.Services.Calculator.Queries
{
	public interface ICalculateEVService
	{
		Result<ResCalculateEVDto> Execute(Guid EVId);
	}
}
