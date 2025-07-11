using EV.Domain.Entities.Day;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Domain.Entities.Lessson
{
    public class LessonGroup
    {
        [Key]
        public  Guid Id { get; set; }
        public string Code { get; set; }
        public virtual ICollection<LessonGruopClass> lessonGruopClasses { get; set; }
        public string TeacherName { get; set; }
        public DateTime ExamDate { get; set; }
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

    }
}
