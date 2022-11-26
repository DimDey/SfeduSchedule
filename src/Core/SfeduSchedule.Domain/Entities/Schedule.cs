using SfeduSchedule.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SfeduSchedule.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public ICollection<Day> Days { get; set; }
    }
}
