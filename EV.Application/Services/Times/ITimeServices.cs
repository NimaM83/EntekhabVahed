using EV.Application.Interfaces.Context;
using EV.Application.Services.Times.Commands.AddTimes;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Times
{
    public interface ITimeServices
    {
        IAddTimeService AddTime { get; }
    }

    public class TimeServices : ITimeServices
    {
        private readonly IDataBaseContext _context;
        public TimeServices(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddTimeService _addTime;
        public IAddTimeService AddTime 
        {
            get
            {
                return _addTime = _addTime ?? new AddTimeService(_context);
            }
        }
    }
}
