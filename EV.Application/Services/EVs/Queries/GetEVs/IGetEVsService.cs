﻿using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs.Queries.GetEVs
{
	public interface IGetEVsService
	{
		Result<ResGetEvsDto> Execute();	
	}
}
