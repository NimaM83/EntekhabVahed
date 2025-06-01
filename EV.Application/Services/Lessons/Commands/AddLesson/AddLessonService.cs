using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Lessson;

namespace EV.Application.Services.Lessons.Commands.AddLesson
{
    public class  AddLessonService : IAddLessonService
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

                    List<LessonGroup> Groups = new List<LessonGroup>();
                    foreach(var item in request.Groups)
                    {
                        if(!(item.Code == null ||
                           item.TeacherName == null))
                        {
							Groups.Add(new LessonGroup()
							{
								Code = item.Code,
								TimeId = item.TimeId,
                                Day = item.Day,
								TeacherName = item.TeacherName,
								LessonId = newLesson.Id
							});
						}
                    }

                    _context.LessonGroups.AddRange(Groups);
                    _context.SaveChanges();

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
    }
}
