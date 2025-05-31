using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Commands.AddLesson
{
    public class AddLessonItem
    {
        public long Code { get; set; }
        public Guid TimeId {  get; set; }
        public string TeacherName {  get; set; }
    }
}
