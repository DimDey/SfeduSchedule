using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class ScheduleConfiguration : BaseEntityConfiguration<Schedule>
    {
        protected override void BuildConfig(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasOne(x => x.Group)
                .WithOne(x => x.Schedule);

            builder.HasMany(x => x.Days)
                .WithOne(x => x.Schedule);
        }

        protected override string GetTableName()
        {
            return "Schedules";
        }
    }
}
