using EV.Domain.Entities.Chart;
using EV.Domain.Entities.Lessson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.EV
{
	public class EV
	{
		[Key]
		public Guid Id { get; set; }
		public EVState State { get; set; }
		public string Title { get; set; }

		public List<Guid> LessonsId { get; set; }
		public virtual ICollection<Chart.Chart> Charts { get; set; }
		public virtual ICollection<Lesson> Lessons { get; set; }
		public virtual ICollection<Time.Time> Times { get; set; }
	}
}
