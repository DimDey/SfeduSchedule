namespace SfeduSchedule.Domain.Entities
{
    public class Day : BaseEntity
    {
        public virtual Schedule Schedule { get; set; }
        public ICollection<Couple> Couples { get; set; }
    }
}
