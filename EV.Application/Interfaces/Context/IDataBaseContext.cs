using EV.Domain.Entities.Chart;
using EV.Domain.Entities.Lessson;
using EV.Domain.Entities.Time;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<Time> Times { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<LessonGroup> LessonGroups { get; set; }
        DbSet<LessonGruopClass> Classes { get; set; }
        DbSet<Chart> Charts {  get; set; }
    
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
    }
}
