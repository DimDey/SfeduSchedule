using SfeduSchedule.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SfeduSchedule.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public virtual ICollection<Day> Days { get; set; }
    }
}
