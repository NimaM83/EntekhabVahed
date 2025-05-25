using EV.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Services.Times.Commands.AddTimes
{
    public interface IAddTimeService
    {
        Result Execute(List<ReqAddTimeService> request);
    }
}
