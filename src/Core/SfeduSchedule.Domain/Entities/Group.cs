using System;

namespace SfeduSchedule.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public Schedule? Schedule { get; set; }
    }
}
