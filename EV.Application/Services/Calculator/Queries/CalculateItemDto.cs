using EV.Domain.Entities.Day;
using EV.Domain.Entities.Time;


namespace EV.Application.Services.Calculator.Queries
{
	public class CalculateItemDto
	{
		public int LessonNum {  get; set; }
		public Guid LessonId { get; set; }

		public Guid GruopId { get; set; }

		public Time Time { get; set; }
		public EDay Day { get; set; }
		public bool IsLastGroup {  get; set; }	
	}
}
