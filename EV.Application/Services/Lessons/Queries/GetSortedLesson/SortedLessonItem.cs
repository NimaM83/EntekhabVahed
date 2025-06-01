namespace EV.Application.Services.Lessons.Queries.GetSortedLesson
{
	public class SortedLessonItem
	{
		public Guid LessonId { get; set; }
		public List<LessonGroupItem> Groups { get; set; }
	}
}
