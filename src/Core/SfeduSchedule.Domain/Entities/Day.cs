namespace SfeduSchedule.Domain.Entities
{
    public class Day : BaseEntity
    {
        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual ICollection<Couple> Couples { get; set; }
    }
}
