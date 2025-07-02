using EV.Domain.Entities.EV;

namespace EV.Application.Services.EVs.Queries.GetEVs
{
	public class ItemGetEvsDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string StateStr { get; set; }
		public EVState State { get; set; }

	}
}
