using EV.Application.Interfaces.Context;
using EV.Domain.Entities.Common;
using EV.Domain.Entities.EV;

namespace EV.Application.Services.EVs.Commands.AddEV
{
	public class AddNewEVService : IAddNewEVService
	{
		private readonly IDataBaseContext _dbContext;
		public AddNewEVService(IDataBaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Result<Guid> Execute (string title)
		{
			try
			{
				var newEV = new Domain.Entities.EV.EV()
				{
					Title = title,
					State = EVState.SetTime,
					LessonsId = new List<Guid>()
				};

				_dbContext.EVs.Add(newEV);
				_dbContext.SaveChanges();

				return new Result<Guid>()
				{
					IsSuccess = true,
					Message = "انتخاب واحد با موفقیت ساخته شد",
					Data = newEV.Id
				};
				

			} catch(Exception ex)
			{
				return new Result<Guid>()
				{
					IsSuccess = false,
					Message = "خطای نامشخصی رخ داد"
				};
			}
		}
	}

}
