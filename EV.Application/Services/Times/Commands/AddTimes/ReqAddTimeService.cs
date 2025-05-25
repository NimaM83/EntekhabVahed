namespace EV.Application.Services.Times.Commands.AddTimes
{
    public class ReqAddTimeService
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid BrwoserId { get; set; }
    }
}
