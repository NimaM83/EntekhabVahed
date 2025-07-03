using EV.Application.Interfaces.Context;
using EV.Application.Services.Lessons;
using EV.Application.Services.Times;
using EV.Domain.Entities.Common;


namespace EV.Application.Services.Calculator.Queries
{
	public class CalculateEVService : ICalculateEVService
	{
		private readonly ILessonServices _lessonServices;
		private readonly IDataBaseContext _dbContext;
		public CalculateEVService(ILessonServices lessonServices, IDataBaseContext dbContext)
		{
			_lessonServices = lessonServices;
			_dbContext = dbContext;
		}

		public Result<ResCalculateEVDto> Execute(Guid EVId)
		{
			try
			{
				var queuedLessons = _lessonServices.GetQueuedLessons.Execute(EVId);

				if(queuedLessons.IsSuccess)
				{
					List<List<CalculateItemDto>> acceptedArrenge = new List<List<CalculateItemDto>>();
					Stack<CalculateItemDto> tempStack = new Stack<CalculateItemDto>();

					while (true)
					{
						int i = 0;
						CalculateItemDto tempStackItem;
						if (tempStack.Any())
						{
							while(tempStack.Any())
							{
								tempStackItem = tempStack.Pop();
								if(!tempStackItem.IsLastGroup)
								{
									i = tempStackItem.LessonNum;
									break;
								}
								
							}

							if (!tempStack.Any())
							{
								break;
							}
						}


						for (; i < queuedLessons.Data.Lessons.Count(); i++)
						{
							if(!tempStack.Any())
							{

								var tempQueueItem = queuedLessons.Data.Lessons[0].Dequeue();
								tempStack.Push(new CalculateItemDto()
								{
									LessonId = tempQueueItem.LessonId,
									GruopId = tempQueueItem.GroupId,
									classes = _dbContext.Classes.Where(c => c.GruopId == tempQueueItem.GroupId).ToList(),
									LessonNum = 0,
									IsLastGroup = tempQueueItem.IsLastGroup,
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
										classes = _dbContext.Classes.Where(c => c.GruopId == tempQueuedItem.GroupId).ToList(),
										IsLastGroup = tempQueuedItem.IsLastGroup,
									});

									queuedLessons.Data.Lessons[i].Enqueue(tempQueuedItem);
								
							}
						}

						if (IsValidEV(tempStack))
						{
							acceptedArrenge.Add(tempStack.ToList());
						}
					}

					return new Result<ResCalculateEVDto>()
					{
						IsSuccess = true,
						Message = "انتخاب واحد با موفقیت انجام شد",
						Data = new ResCalculateEVDto()
						{
							acceptedArrenge = acceptedArrenge.ToList(),
						}
					};
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

		private bool IsValidEV(Stack<CalculateItemDto> stack)
		{
			CalculateItemDto[] lessonItems = new CalculateItemDto[stack.Count];
			for(int i = stack.Count-1; i >= 0; i--)
			{
				lessonItems[i] = stack.Pop();
			} // this loop makes the stack empty

			foreach(var item in lessonItems)
			{
				stack.Push(item);
			}// this loop refill th stack


			List<CalculateItemDto> existTimes = new List<CalculateItemDto>();
			existTimes.Add(lessonItems[0]);

			for(int i = 1; i < lessonItems.Length; i++)
			{
				if (ValidTime.CheckValidClasses(lessonItems[i], existTimes))
				{
					existTimes.Add(lessonItems[i]);
				}

				else
				{
					return false;
				}
			}

			return true;
		}
	}
}
