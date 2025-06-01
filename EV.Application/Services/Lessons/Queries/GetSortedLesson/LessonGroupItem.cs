using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Queries.GetSortedLesson
{
	public class LessonGroupItem
	{
		public Guid LessonGroupId { get; set; }
		public Time Time { get; set; }
		public EDay Day { get; set; }
	}
}
