using EV.Application.Services.Calculator.Queries;
using EV.Application.Services.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Calculator
{
	public interface ICalculatorServices
	{
		ICalculateEVService CalculateEV { get; }
	}

	public class CalculatorServices : ICalculatorServices
	{
		private readonly ILessonServices _lessonServices;

		public CalculatorServices(ILessonServices lessonServices)
		{
			_lessonServices = lessonServices;
		}

		private ICalculateEVService _calculateEV;
		public ICalculateEVService CalculateEV
		{
			get
			{
				return _calculateEV = _calculateEV ?? new CalculateEVService(_lessonServices);
			}
		}
	}
}
