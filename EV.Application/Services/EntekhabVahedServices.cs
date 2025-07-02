using EV.Application.Interfaces.Context;
using EV.Application.Interfaces.Services;
using EV.Application.Services.Calculator;
using EV.Application.Services.Chart;
using EV.Application.Services.Days;
using EV.Application.Services.EVs;
using EV.Application.Services.Lessons;
using EV.Application.Services.Times;


namespace EV.Application.Services
{
    public class EntekhabVahedServices : IEntekhabVahedServices
    {
        private readonly IDataBaseContext _context;
        public EntekhabVahedServices(IDataBaseContext context)
        { 
            _context = context;
        }

        private ITimeServices _timeServices;
        public ITimeServices TimeServices
        {
            get
            {
                return _timeServices = _timeServices ?? new TimeServices(_context);
            }
        }

        private ILessonServices _lessonServices;
        public  ILessonServices LessonServices
        {
            get
            {
                return _lessonServices = _lessonServices ?? new LessonServices(_context);
            }
        }

        private IDaysServices _daysServices;
        public IDaysServices DaysServices
        {
            get
            {
                return _daysServices = _daysServices ?? new DaysServices();
            }
        }

        private ICalculatorServices _calculatorServices;
        public ICalculatorServices CalculatorServices
        {
            get
            {
                return _calculatorServices = _calculatorServices ?? new CalculatorServices(LessonServices, _context);
            }
        }

        private IChartServices  _chartServices;
        public IChartServices   ChartServices
        {
            get
            {
                return _chartServices = _chartServices ?? new ChartServices(_context);
            }
        }

        private IEVsServices _EVsServices;
        public IEVsServices EVsServices
        {
            get
            {
                return _EVsServices = _EVsServices ?? new EVsServices(_context,ChartServices);
            }
        }
    }
}
