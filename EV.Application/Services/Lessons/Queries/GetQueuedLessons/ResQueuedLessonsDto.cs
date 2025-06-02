namespace EV.Application.Services.Lessons.Queries.GetQueuedLessons
{
	public class ResQueuedLessonsDto
	{
		public List<Queue<QueueItemDto>> Lessons { get; set; }
	}
}
