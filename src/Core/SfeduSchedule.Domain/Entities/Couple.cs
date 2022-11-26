using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Domain.Entities
{
    public class Couple : BaseEntity
    {
        public Guid DayId { get; set; }
        public Day Day { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string ClassRoom { get; set; }
        public string Teacher { get; set; }
        public bool? OnEven { get; set; }
        public int? SubGroup { get; set; }
    }
}