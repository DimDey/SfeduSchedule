namespace SfeduSchedule.Domain.Entities
{
	public class Group : BaseEntity
	{
		public string Name { get; set; }

		public Guid FacultyId { get; set; }

		public virtual Faculty Faculty { get; set; }

		public virtual ICollection<DayEvent> Events { get; set; }
	}
}