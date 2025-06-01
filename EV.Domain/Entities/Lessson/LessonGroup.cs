using EV.Domain.Entities.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.Lessson
{
    public class LessonGroup
    {
        public  Guid Id { get; set; }
        public string Code { get; set; }
        public Time.Time Time { get; set; }
        public EDay Day { get; set; }
        public Guid TimeId { get; set; }
        public string TeacherName { get; set; }
        public Guid LessonId { get; set; }

    }
}
