namespace EV.Application.Services.Chart.Queries.GetChartDetails
{
	public class ResChartDetailsDto
	{
		public ChartDetailsItem[] LessonsOnDay { get; set; } = new ChartDetailsItem[6];
		public List<ExamDateItem> ExamDates { get; set; }
	}
}
