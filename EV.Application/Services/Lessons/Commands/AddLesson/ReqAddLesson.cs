namespace EV.Application.Services.Lessons.Commands.AddLesson
{
    public class ReqAddLessonDto
    {
        public string Name { get; set; }
        public int unit { get; set; }
        public List<AddLessonItem> Groups { get; set; }
    }
}
