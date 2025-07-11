using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Queries.GetSortedLesson
{
	public class LessonGroupItem
	{
		public Guid LessonGroupId { get; set; }
		public List<Guid> ClassesId { get; set; }
		public DateTime ExamDate { get; set; }

	}
}
