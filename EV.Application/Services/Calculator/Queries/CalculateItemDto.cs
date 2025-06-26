using EV.Domain.Entities.Day;
using EV.Domain.Entities.Lessson;
using EV.Domain.Entities.Time;


namespace EV.Application.Services.Calculator.Queries
{
	public class CalculateItemDto
	{
		public int LessonNum {  get; set; }
		public Guid LessonId { get; set; }

		public Guid GruopId { get; set; }
		public List<LessonGruopClass> classes { get; set; }
		public bool IsLastGroup {  get; set; }	
	}
}
