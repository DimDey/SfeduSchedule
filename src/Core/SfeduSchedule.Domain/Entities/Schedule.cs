using SfeduSchedule.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SfeduSchedule.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Guid EntityId { get; set; }
        public virtual Group Entity { get; set; }
        public virtual ICollection<Day> Days { get; set; }
    }
}
