using EV.Application.Services.Lessons;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Calculator.Queries
{
	public interface ICalculateEVService
	{
		Result<ResCalculateEVDto> Execute();
	}

	public class CalculateEVService : ICalculateEVService
	{
		private readonly ILessonServices _lessonServices;
		public CalculateEVService(ILessonServices lessonServices)
		{
			_lessonServices = lessonServices;
		}

		public Result<ResCalculateEVDto> Execute()
		{
			try
			{
				var queuedLessons = _lessonServices.GetQueuedLessons.Execute();

				if(queuedLessons.IsSuccess)
				{
					List<Stack<CalculateItemDto>> acceptedArrenge = new List<Stack<CalculateItemDto>>();
					bool flag = true;

					while (flag)
					{
						Stack<CalculateItemDto> tempStack = new Stack<CalculateItemDto>();
						for(int i = 0; i < queuedLessons.Data.Lessons.Count(); i++)
						{
							if(!tempStack.Any())
							{

								var tempQueueItem = queuedLessons.Data.Lessons[0].Dequeue();
								tempStack.Push(new CalculateItemDto()
								{
									LessonId = tempQueueItem.LessonId,
									GruopId = tempQueueItem.GroupId,
									Time = tempQueueItem.Time,
									Day = tempQueueItem.Day,
									LessonNum = 0,

								});

								queuedLessons.Data.Lessons[0].Enqueue(tempQueueItem);
							}
							else
							{

									var tempQueuedItem = queuedLessons.Data.Lessons[i].Dequeue();
									tempStack.Push(new CalculateItemDto()
									{
										LessonNum = i,
										LessonId = tempQueuedItem.LessonId,
										GruopId = tempQueuedItem.GroupId,
										Time = tempQueuedItem.Time,
										Day = tempQueuedItem.Day,
									});

									queuedLessons.Data.Lessons[i].Enqueue(tempQueuedItem);
								
							}
						}
					}
				}

				return new Result<ResCalculateEVDto>()
				{
					IsSuccess = false,
					Message = queuedLessons.Message,
				};
			}
			catch (Exception ex)
			{
				return new Result<ResCalculateEVDto>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}

	public class ResCalculateEVDto
	{
		public List<Stack<CalculateItemDto>> acceptedArrenge {  get; set; }
	}

	public class CalculateItemDto
	{
		public int LessonNum {  get; set; }
		public Guid LessonId { get; set; }

		public Guid GruopId { get; set; }

		public Time Time { get; set; }
		public EDay Day { get; set; }
	}
}
