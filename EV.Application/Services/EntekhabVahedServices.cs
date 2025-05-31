using EV.Application.Interfaces.Context;
using EV.Application.Interfaces.Services;
using EV.Application.Services.Lessons;
using EV.Application.Services.Times;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
