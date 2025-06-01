using EV.Application.Interfaces.Context;
using EV.Application.Services.Times.Commands.AddTimes;
using EV.Application.Services.Times.Queries.GetTimes;
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
        IGetTimesService GetTimes { get; }
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

        private IGetTimesService _getTimes;
        public IGetTimesService GetTimes
        {
            get
            {
                return _getTimes = _getTimes ?? new GetTimesServiec(_context);
            }
        }
    }
}
