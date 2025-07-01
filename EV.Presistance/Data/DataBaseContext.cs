using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Chart;
using EV.Domain.Entities.EV;
using EV.Domain.Entities.Lessson;
using EV.Domain.Entities.Time;
using Microsoft.EntityFrameworkCore;

namespace EV.Presistance.Data
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Lesson> Lessons {  get; set; }
        public DbSet<LessonGroup> LessonGroups { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<LessonGruopClass> Classes { get; set; }
        public DbSet<Domain.Entities.EV.EV> EVs { get; set; }
	}
}
