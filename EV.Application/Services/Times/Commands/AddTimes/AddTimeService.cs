using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.Time;

namespace EV.Application.Services.Times.Commands.AddTimes
{
    public class AddTimeService : IAddTimeService
    {
        private readonly IDataBaseContext _context;
        public AddTimeService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(List<ReqAddTimeService> request)
        {
            try
            {
                List<Time> ExistTimes = new List<Time>();
                ExistTimes.Add(new Time()
                {
                    From = request.First().From,
                    To = request.First().To,
                });

				if (ExistTimes.First().From >= ExistTimes.First().To)
				{
					return new Result()
					{
						IsSuccess = false,
						Message = "ساعت شروع کلاس نمیتواند بیشتر از ساعت پایان ان باشد"
					};
				}

				Time temp;
                for (int i = 1; i < request.Count(); i++)
                {
                    temp = new Time()
                    {
                        From = request.ElementAt(i).From,
                        To = request.ElementAt(i).To,
                    };

                    if(temp.From >= temp.To)
                    {
                        return new Result()
                        {
                            IsSuccess = false,
                            Message = "ساعت شروع کلاس نمیتواند بیشتر از ساعت پایان ان باشد"
                        };
                    }

                    if (ValidTime.CheckValidTime(temp, ExistTimes))
                    {
                        ExistTimes.Add(temp);
                    }
                    else
                    {
                        return new Result()
                        {
                            IsSuccess = false,
                            Message = "زمان هایی که وارد کردید با هم تداخل دارند،\n لطفا برسی کرده و دوباره امتحان کنید"
                        };
                    }
                }

                _context.Times.AddRange(ExistTimes);
                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "لیست زمان ها با موفقیت ثبت شدند"
                };

            }
            catch (Exception ex)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Message = "خطای نا مشخصی رخ داد!\nلطفا دوباره از اول تلاش کنید"
                };
            }
        }
    }
}
