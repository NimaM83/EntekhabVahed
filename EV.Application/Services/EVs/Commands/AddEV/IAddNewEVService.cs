using EV.Domain.Entities.Common;
using EV.Domain.Entities.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs.Commands.AddEV
{
	public interface IAddNewEVService
	{
		Result<Guid> Execute(string title);
	}

}
