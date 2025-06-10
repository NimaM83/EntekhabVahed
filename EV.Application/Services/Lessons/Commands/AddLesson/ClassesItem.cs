using EV.Domain.Entities.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Lessons.Commands.AddLesson
{
	public class ClassesItem
	{
		public Guid TimeId { get; set; }
		public EDay Day { get; set; }
	}
}
