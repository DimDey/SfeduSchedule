using System;

namespace SfeduSchedule.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
