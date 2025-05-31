using EV.Application.Interfaces.Context;
using EV.Application.Services.Lessons.Commands.AddLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Lessons
{
    public interface ILessonServices
    {
        IAddLessonService AddLesson { get; }
    }

    public class LessonServices : ILessonServices
    {
        private readonly IDataBaseContext _context;
        public LessonServices (IDataBaseContext context)
        {
            _context = context;
        }

        private IAddLessonService _addLesson;
        public IAddLessonService AddLesson
        {
            get
            {
                return _addLesson = _addLesson ?? new AddLessonService(_context);
            }
        }



    }
}
