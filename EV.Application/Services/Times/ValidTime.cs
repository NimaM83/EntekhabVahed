using EV.Application.Services.Calculator.Queries;
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

        public static bool CheckValidTimeWithDays (CalculateItemDto target, List<CalculateItemDto> existTimes)    
        { 
            foreach(var item in existTimes)
            {
                if(target.Day.Equals(item.Day))
                {
					if ((target.Time.From.Equals(item.Time.From)) && (target.Time.To.Equals(item.Time.To)))
					{
						return false;
					}
				}
            }

            return true;
        }

	}
}
