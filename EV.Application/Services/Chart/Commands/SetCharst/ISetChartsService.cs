using EV.Domain.Entities.Chart;
using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Chart.Commands.SetCharst
{
	public interface ISetChartsService
	{
		Result Execute(ReqSetChartDto request);
	}
		
}
