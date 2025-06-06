using EV.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Chart.Queries.GetChartDetails
{
	public interface IGetChartDatilsService
	{
		Result<ResChartDetailsDto> Execute (Guid chartId);
	}
}
