using EV.Application.Services.Calculator.Queries;
using EV.Domain.Entities.Time;
using System.Reflection.Metadata.Ecma335;


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

        public static bool CheckValidExamDate(CalculateItemDto target, List<CalculateItemDto> existTimes)
        {
            foreach (var item in existTimes)
            {
                if(target.ExamDate.Date == item.ExamDate.Date)
                {
                    if((target.ExamDate.TimeOfDay < item.ExamDate.AddHours(2).TimeOfDay) && 
                     (target.ExamDate.TimeOfDay >= item.ExamDate.TimeOfDay))
                    {
                        return false;
                    }

                    else if((item.ExamDate.TimeOfDay < target.ExamDate.AddHours(2).TimeOfDay) &&
                            (item.ExamDate.TimeOfDay >= target.ExamDate.TimeOfDay))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
	}
}
