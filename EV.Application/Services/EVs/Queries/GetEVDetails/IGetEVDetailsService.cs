using EV.Application.Services.Chart.Queries.GetChartDetails;
using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EV.Application.Services.EVs.Queries.GetEVDetails
{
	public interface IGetEVDetailsService
	{
		Result<ResGetEVDetailsDto> Execute(Guid EVId);
	}
}
