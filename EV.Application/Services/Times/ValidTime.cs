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

        public static bool CheckValidClasses (CalculateItemDto target, List<CalculateItemDto> existTimes)    
        { 
            foreach(var item in existTimes)
            {
                foreach(var innerItem in item.classes)
                {
                    foreach(var targetItem in target.classes)
                    {
                        if(targetItem.Day.Equals(innerItem.Day))
                        {
                            if(targetItem.Time.From.Equals(innerItem.Time.From) &&
                                targetItem.Time.To.Equals(innerItem.Time.To))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

	}
}
