namespace SfeduSchedule.Domain.Entities
{
	public class Faculty : BaseEntity
	{
		public string Name { get; set; }

		public Guid InstituteId { get; set; }

		public virtual Institute Institute { get; set; }

		public virtual ICollection<Group> Groups { get; set; }
	}
}