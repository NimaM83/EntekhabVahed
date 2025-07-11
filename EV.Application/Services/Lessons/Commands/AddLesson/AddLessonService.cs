using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Lessson;
using System.Globalization;
using PersianDate;
using PersianDate.Standard;

namespace EV.Application.Services.Lessons.Commands.AddLesson
{
    public class AddLessonService : IAddLessonService
    {
        private readonly IDataBaseContext _context;
        public AddLessonService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (ReqAddLessonDto request)
        {
            try
            {
                if(request.Groups.Any())
                {
                    Lesson newLesson = new Lesson()
                    {
                        Name = request.Name,
                        Unit = request.unit
                    };
                    _context.Lessons.Add(newLesson);
					_context.SaveChanges();

                    var foundedEV = _context.EVs.Find(request.EVId);
                    foundedEV.LessonsId.Add(newLesson.Id);


					foreach (var item in request.Groups)
                    {
                        LessonGroup newLessonGroup = new LessonGroup()
                        {
                            Code = item.Code,
                            TeacherName = item.TeacherName,
                            LessonId = newLesson.Id,
                            ExamDate = GetExamDateTime(item.ExamDate,item.ExamTime)
                        };
                        _context.LessonGroups.Add(newLessonGroup);
						_context.SaveChanges();


						foreach (var inerItem in item.Classes)
                        {
                            _context.Classes.Add(new LessonGruopClass()
                            {
                                TimeId = inerItem.TimeId,
                                Day = inerItem.Day,
                                LessonGroup = newLessonGroup,
                                GruopId = newLessonGroup.Id,
                            });
							_context.SaveChanges();
						}
                    }

                    

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "درس با  موفقیت اقزوده شد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "حداقل یک گروه درسی باید وارد کنید"
                };
            } catch(Exception ex)
            {
                return new Result()
                {
                    IsSuccess  = false,
                    Message  = "خطای نا مشخصی رخ داد"
                };
            }
        }

        private DateTime GetExamDateTime (int[] ExamDate, TimeOnly ExamTime)
        {

            var result = ConvertDate.ToEn(ExamDate[0], ExamDate[1], ExamDate[2]);

            result += ExamTime.ToTimeSpan();

            return result;
            
        }

    }
}
