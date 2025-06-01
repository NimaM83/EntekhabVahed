using EV.Application.Services.Days;
using EV.Application.Services.Lessons;
using EV.Application.Services.Times;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Application.Interfaces.Services
{
    public interface IEntekhabVahedServices
    {
        ITimeServices TimeServices { get; }
        ILessonServices LessonServices { get; }
        IDaysServices DaysServices { get; }
    }
}
