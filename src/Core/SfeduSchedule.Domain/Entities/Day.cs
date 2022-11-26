namespace SfeduSchedule.Domain.Entities
{
    public class Day : BaseEntity
    {
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public ICollection<Couple> Couples { get; set; }
    }
}
