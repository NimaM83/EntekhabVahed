﻿using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Lessson;
using Microsoft.EntityFrameworkCore;

namespace EV.Application.Services.Lessons.Queries.GetSortedLesson
{
	public class GetSortedLessonService : IGetSortedLessonService
	{
		private readonly IDataBaseContext _context;
		public GetSortedLessonService(IDataBaseContext context)
		{
			_context = context;
		}

		public Result<ResSortedLessonDto> Execute(Guid EVId)
		{
			try
			{
				var foundedEV = _context.EVs.Find(EVId);

				List<Lesson> foundedLesson = new List<Lesson>();
				foreach(var item in foundedEV.LessonsId)
				{
					foundedLesson.Add
						(
							_context.Lessons.Where(l => l.Id.Equals(item))
											.Include(l => l.LessonGroups)
											.ThenInclude(g => g.lessonGruopClasses)
											.ThenInclude(c => c.Time)
											.FirstOrDefault() ?? throw new NullReferenceException()
						);
				}

				Lesson min;
				Lesson temp;
				for(int i = 0; i < foundedLesson.Count(); i++)
				{
					min = foundedLesson[i];
					for(int j = i+1; j < foundedLesson.Count(); j++)
					{
						if (foundedLesson[j].LessonGroups.Count() < min.LessonGroups.Count())
						{
							temp = min;
							min = foundedLesson[j];
							foundedLesson[i] = foundedLesson[j];
							foundedLesson[j] = temp;
						}
					}
				}// sorting lessons by lessonGroups count

				ResSortedLessonDto result = new ResSortedLessonDto();


				List<SortedLessonItem> lessons = new List<SortedLessonItem>();
				foreach(var item in foundedLesson)
				{

					List<LessonGroupItem> lessonGroups = new List<LessonGroupItem>();
					foreach (var inerItem in item.LessonGroups)
					{
						lessonGroups.Add(new LessonGroupItem()
						{
							LessonGroupId = inerItem.Id,
							ClassesId = inerItem.lessonGruopClasses.Select(C => C.Id).ToList(),
							ExamDate = inerItem.ExamDate
						});
					}

					lessons.Add(new SortedLessonItem()
					{
						Groups = lessonGroups,
						LessonId = item.Id,
					});
				}

				result.Lessons = lessons;


				return new Result<ResSortedLessonDto>()
				{
					IsSuccess = true,
					Message = "دروس منظم شدند",
					Data = result
				};

			}
			catch (Exception ex)
			{
				return new Result<ResSortedLessonDto>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}
}
