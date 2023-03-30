namespace SfeduSchedule.Domain.Entities
{
	public enum DayNumber
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
	}

	public class DayEvent : BaseEntity
	{
		public Guid GroupId { get; set; }

		public DayNumber DayNumber { get; set; }

		public TimeSpan Begin { get; set; }
		
		public TimeSpan End { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string ClassRoom { get; set; }

		public string Teacher { get; set; }

		public bool? OnEven { get; set; }

		public int? SubGroup { get; set; }

		public virtual Group Group { get; set; }
	}
}