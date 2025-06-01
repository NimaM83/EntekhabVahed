using EV.Application.Interfaces.Context;
using EV.Application.Interfaces.Services;
using EV.Application.Services.Days;
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
    }
}
