using EV.Domain.Entities.Day;


namespace EV.Domain.Entities.Lessson
{
	public class LessonGruopClass
	{
		public Guid Id { get; set; }
		public Guid TimeId { get; set; }
		public virtual Time.Time Time { get; set; }
		public EDay Day { get; set; }
		public Guid GruopId { get; set; }
		public virtual LessonGroup LessonGroup { get; set; }
	}
}
