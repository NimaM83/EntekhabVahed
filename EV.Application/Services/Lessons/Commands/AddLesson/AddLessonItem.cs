using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Lessons.Commands.AddLesson
{
    public class AddLessonItem
    {
        public string Code { get; set; }
        public List<ClassesItem> Classes { get; set; }
        public string TeacherName {  get; set; }
        public int[] ExamDate { get; set; } = new int[3];
        public TimeOnly ExamTime { get; set; }
    }
}
