using SfeduSchedule.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SfeduSchedule.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Group Group { get; set; }
        public ICollection<Day> Days { get; set; }
    }
}
