using EV.Domain.Entities.Day;
using EV.Domain.Entities.Lessson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.Chart
{
	public class Chart
	{
		public Guid Id { get; set; }
		public List<Guid> LessonGroupsId { get; set; }
		public virtual ICollection<LessonGroup> LessonGruops { get; set; }
		public Guid EVId { get; set; }
	}
}
