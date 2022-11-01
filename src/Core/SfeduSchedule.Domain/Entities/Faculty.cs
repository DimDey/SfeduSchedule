using System;

namespace SfeduSchedule.Domain.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public Institute Institute { get; set; }
        public ICollection<Group> Groups { get; set; }

    }
}
