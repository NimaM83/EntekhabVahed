using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Times.Commands.AddTimes
{
	public class TimeDto
	{
		public TimeOnly From { get; set; }
		public TimeOnly To { get;set; }
	}
}
