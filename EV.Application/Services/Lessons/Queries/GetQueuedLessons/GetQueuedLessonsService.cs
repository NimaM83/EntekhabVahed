using EV.Application.Services.Lessons.Queries.GetSortedLesson;
using EV.Domain.Entities.Common;

namespace EV.Application.Services.Lessons.Queries.GetQueuedLessons
{
	public class GetQueuedLessonsService : IGetQueuedLessonsService
	{
		private readonly IGetSortedLessonService _sortedLessons;

		public GetQueuedLessonsService (IGetSortedLessonService sortedLessons)
		{
			_sortedLessons = sortedLessons;
		}

		public Result<ResQueuedLessonsDto> Execute ()
		{
			try
			{
				var sortedLessons = _sortedLessons.Execute();

				if(sortedLessons.IsSuccess)
				{
					List<Queue<QueueItemDto>> lessons = new List<Queue<QueueItemDto>>();
					Queue<QueueItemDto> temp;
					foreach (var item in sortedLessons.Data.Lessons)
					{
						temp = new Queue<QueueItemDto>();
						foreach (var inerItem in item.Groups)
						{
							temp.Enqueue(new QueueItemDto()
							{
								LessonId = item.LessonId,
								GroupId = inerItem.LessonGroupId,
								Time = inerItem.Time,
								Day = inerItem.Day,
								IsLastGroup = false,
							});

						}

						temp.Last().IsLastGroup = true;
						lessons.Add(temp);
					}

					return new Result<ResQueuedLessonsDto>()
					{
						IsSuccess = true,
						Message = "دروس صف بندی شدند",
						Data = new ResQueuedLessonsDto()
						{
							Lessons = lessons
						}
					};
				}

				return new Result<ResQueuedLessonsDto>()
				{
					IsSuccess = false,
					Message = sortedLessons.Message
				};
			}
			catch (Exception ex)
			{
				return new Result<ResQueuedLessonsDto>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}
}
