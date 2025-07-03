using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Lessson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.EVs.Commands.RemoveEV
{
	public interface IRemoveEVService
	{
		Result Execute(Guid EVId);
	}

	public class RemoveEVService : IRemoveEVService
	{
		private readonly IDataBaseContext _dbContext;
		public RemoveEVService(IDataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Result Execute (Guid EVId)
		{
			try
			{
				var foundedEV = _dbContext.EVs.Find(EVId);

				if(foundedEV is not null)
				{
					foreach(var item in foundedEV.LessonsId)
					{
						Lesson lesson = _dbContext.Lessons.Where(l => l.Id.Equals(item))
													   .Include(l => l.LessonGroups)
													   .ThenInclude(g => g.lessonGruopClasses)
													   .ThenInclude(c => c.Time)
													   .FirstOrDefault() ?? 
													   throw new NullReferenceException(); 

						_dbContext.Lessons.Remove(lesson);
					}

					_dbContext.EVs.Remove(foundedEV);
					_dbContext.SaveChanges();

					return new Result()
					{
						IsSuccess = true,
						Message = "انتخاب واحد با موفقیت حذف شد"
					};
				}

				return new Result()
				{
					IsSuccess = false,
					Message = "انتخاب واحد یافت نشد"
				};
			} catch(Exception ex)
			{
				return new Result()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}
}
