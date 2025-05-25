using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Time;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Presistance.Data
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
    }
}
