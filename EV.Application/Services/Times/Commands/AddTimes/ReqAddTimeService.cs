namespace EV.Application.Services.Times.Commands.AddTimes
{
    public class ReqAddTimeService
    {
        public List<TimeDto> Times { get; set; }
        public Guid EVId { get; set; }
    }
}
