using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Queries.GetQueuedLessons
{
	public class QueueItemDto
	{
		public Guid LessonId { get; set; }
		public Guid GroupId { get; set; }
		public Time Time { get; set; }
		public EDay Day { get; set; }
	}
}
