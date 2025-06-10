using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Queries.GetQueuedLessons
{
	public class QueueItemDto
	{
		public Guid LessonId { get; set; }
		public Guid GroupId { get; set; }
		public List<Guid> ClassesId { get; set; }
		public bool IsLastGroup { get; set; }
	}
}
