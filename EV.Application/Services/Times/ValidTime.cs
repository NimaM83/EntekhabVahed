using EV.Domain.Entities.Time;


namespace EV.Application.Services.Times
{
    public class ValidTime
    {
        public static bool CheckValidTime(Time Target, List<Time> ExistTimes)
        {
            foreach(var item in ExistTimes)
            {
                
                if ((Target.From) > (item.From) && (Target.From) < (item.To) ||
					(Target.To) > (item.From) && (Target.To) < (item.To))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
