using EV.Application.Interfaces.Context;
using EV.Application.Services.Lessons.Commands.AddLesson;
using EV.Application.Services.Lessons.Queries.GetQueuedLessons;
using EV.Application.Services.Lessons.Queries.GetSortedLesson;
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
        IGetSortedLessonService GetSortedLesson { get; }
        IGetQueuedLessonsService GetQueuedLessons { get; }
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

        private IGetSortedLessonService _getSortedLesson;
        public IGetSortedLessonService GetSortedLesson
        {
            get
            {
                return _getSortedLesson = _getSortedLesson ?? new GetSortedLessonService(_context);
            }
        }

        private IGetQueuedLessonsService _getQueuedLessons;
        public IGetQueuedLessonsService GetQueuedLessons
        {
            get
            {
                return _getQueuedLessons = _getQueuedLessons ?? new GetQueuedLessonsService(GetSortedLesson);
            }
        }




	}
}
