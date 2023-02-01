namespace SfeduSchedule.Domain.Entities
{
    public class Institute : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}