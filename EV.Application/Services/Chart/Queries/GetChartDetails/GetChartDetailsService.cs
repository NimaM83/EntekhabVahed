using EV.Application.Interfaces.Context;
using EV.Application.Services.Times;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Day;
using EV.Domain.Entities.Lessson;
using EV.Domain.Entities.Time;
using Microsoft.EntityFrameworkCore;
using PersianDate.Standard;
using System.Security.Cryptography;

namespace EV.Application.Services.Chart.Queries.GetChartDetails
{
	public class GetChartDetailsService : IGetChartDatilsService
	{
		private readonly IDataBaseContext _context;
		public GetChartDetailsService (IDataBaseContext context)
		{
			_context = context;
		}

		public Result<ResChartDetailsDto> Execute(Guid chartId)
		{
			try
			{
				var foundedChart = _context.Charts.Where(c => c.Id.Equals(chartId)).FirstOrDefault();

                if (foundedChart != null)
                {
					var foundedTimes = _context.Times.Where(t => t.EVId.Equals(foundedChart.EVId)).ToList();
					foundedTimes = SortTimes(foundedTimes);
					var foundedGroups = new List<LessonGroup>();

					foreach(var item in foundedChart.LessonGroupsId)
					{
						foundedGroups.Add(_context.LessonGroups.Where(g => g.Id.Equals(item))
										  .Include(g => g.lessonGruopClasses).Include(g => g.Lesson)
										  .FirstOrDefault() ?? throw new ArgumentNullException());
					}

					foundedChart.LessonGruops = foundedGroups;
					ResChartDetailsDto result = new ResChartDetailsDto();
					result.ExamDates = new List<ExamDateItem>();

					for(int i = 0; i < 6; i++)
					{
						var item = new ChartDetailsItem();
						item.Lessons = new string[foundedTimes.Count];

						var lessonsOnDay = GetLessonsOnDay(foundedChart.LessonGruops.ToList(), i);
						item.Day = DayToPersian(GetDay(i));

							for (int j = 0; j < foundedTimes.Count; j++)
							{
								item.Lessons[j] = "-";
								if (lessonsOnDay.Any())
								{
									
									for (int k = 0; k < lessonsOnDay.Count; k++)
									{
										if (lessonsOnDay[k].Time.From.Equals(foundedTimes[j].From) &&
											lessonsOnDay[k].Time.To.Equals(foundedTimes[j].To))
										{
											item.Lessons[j] = $"{lessonsOnDay[k].Lesson.Name}\n" +
															  $"{lessonsOnDay[k].LessonGroup.TeacherName}\n" +
															  $"{lessonsOnDay[k].LessonGroup.Code}";
											
											break;
										}
									}

								}
							}

						result.LessonsOnDay[i] = item;

					}

					foreach(var item in foundedGroups.OrderBy(g => g.ExamDate))
					{
						result.ExamDates.Add(new ExamDateItem()
						{
							ExamDate = $"{DayToPersian(item.ExamDate)} - {ConvertDate.ToFa(item.ExamDate)} - {TimeOnly.FromTimeSpan(item.ExamDate.TimeOfDay).ToString("HH:mm")}",
							LessonName = $"({item.TeacherName}){item.Lesson.Name}"
						});
							
					}

					return new Result<ResChartDetailsDto>()
					{
						IsSuccess = true,
						Message = "جدول یافت شد",
						Data = result
					};
                }

				return new Result<ResChartDetailsDto>()
				{
					IsSuccess = false,
					Message = "جدول یافت نشد"
				};

            } catch(Exception ex)
			{
				return new Result<ResChartDetailsDto> ()
				{
					IsSuccess =false,
					Message = "خطای نا مشخصی رخ داد"
				};
			}
		}
		private List<Time> SortTimes(List<Time> times)
		{
			Time min = new Time();
			Time temp = new Time();
			for (int i = 0; i < times.Count; i++)
			{
				min = times[i];
				for (int j = 0; j < times.Count; j++)
				{
					if (times[i].From < min.From)
					{
						temp = min;
						min = times[i];
						times[i] = temp;
					}
				}
			}

			return times;
		}
		private string DayToPersian (EDay day)
		{
			switch(day)
			{
				case EDay.Saturday:
					return "شنبه";

				case EDay.Sunday:
					return "یک شنبه";

				case EDay.Monday:
					return "دو شنبه";

				case EDay.Tuesday:
					return "سه شنبه";

				case EDay.Wednesday:
					return "چهار شنبه";

				case EDay.Thursday:
					return "پنج شنبه";
			}

			return null;
		}
		private string DayToPersian (DateTime dateTime)
		{
			switch(dateTime.DayOfWeek)
			{
				case DayOfWeek.Saturday:
					return "شنبه";

				case DayOfWeek.Sunday:
					return "یک شنبه";

				case DayOfWeek.Monday:
					return "دو شنبه"; 

				case DayOfWeek.Tuesday:
					return "سه شنبه";

				case DayOfWeek.Wednesday:
					return "چهار شنبه";

				case DayOfWeek.Thursday:
					return "پنج شنبه";

				default:
					throw new Exception();

			}
		}
		private EDay GetDay (int number)
		{
			switch(number)
			{
				case 0:
					return EDay.Saturday;

				case 1:
					return EDay.Sunday;

				case 2:
					return EDay.Monday;

				case 3:
					return EDay.Tuesday;

				case 4:
					return EDay.Wednesday;

				case 5:
					return EDay.Thursday;
			}

			throw new Exception();
			return EDay.Thursday;
		}
		private List<LessonsOnDay> GetLessonsOnDay(List<LessonGroup> lessonGroups, int day)
		{
			List<LessonsOnDay> result = new List<LessonsOnDay>();

			foreach(var item in lessonGroups)
			{
				foreach(var innerItem in item.lessonGruopClasses)
				{
					if(innerItem.Day.Equals(GetDay(day)))
					{
						result.Add(new LessonsOnDay()
						{
							Day = innerItem.Day,
							Lesson = item.Lesson,
							LessonGroup = item,
							Time = innerItem.Time
						});
					}
				}
			}

			return result;
		}

	}

	internal class LessonsOnDay
	{
		internal EDay Day { get; set; }
		internal Lesson Lesson { get; set; }
		internal LessonGroup LessonGroup { get; set; }
		internal Time Time { get; set; }

	}
}
