using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.Lessson
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  int Unit { get; set; }

        public virtual ICollection<LessonGroup> LessonGroups { get; set; }
    }
}
