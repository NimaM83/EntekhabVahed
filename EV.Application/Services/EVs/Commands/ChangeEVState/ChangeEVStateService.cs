using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.EV;

namespace EV.Application.Services.EVs.Commands.ChangeEVState
{
	public class ChangeEVStateService : IChangeEVStateService
	{
		private readonly IDataBaseContext _dbContext;
		public ChangeEVStateService(IDataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Result Execute (Guid EVId, EVState newState)
		{
			try
			{
				var foundedEV = _dbContext.EVs.Find(EVId);

				if(foundedEV is not null)
				{
					foundedEV.State = newState;
					_dbContext.SaveChanges();

					return new Result()
					{
						IsSuccess = true,
						Message = "انتخاب واحد به وضعیت جدید تغییر یافت"
					};
				}

				return new Result()
				{
					IsSuccess = false,
					Message = "انتخاب واحد مورد نظر یافت نشد"
				};
			} catch(Exception ex)
			{
				return new Result()
				{
					IsSuccess = false,
					Message = "خطای نا مشخصی رخ داد"
				};
			}
		}
	}
}
