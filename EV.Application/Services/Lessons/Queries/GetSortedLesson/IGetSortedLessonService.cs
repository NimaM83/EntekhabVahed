using EV.Domain.Entities.Common;


namespace EV.Application.Services.Lessons.Queries.GetSortedLesson
{
	public interface IGetSortedLessonService
	{
		Result<ResSortedLessonDto> Execute(Guid EVId);
	}
}
