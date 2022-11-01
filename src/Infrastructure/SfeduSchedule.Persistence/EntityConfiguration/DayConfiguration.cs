using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class DayConfiguration : BaseEntityConfiguration<Day>
    {
        protected override void BuildConfig(EntityTypeBuilder<Day> builder)
        {
            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Days);

            builder.HasMany(x => x.Couples)
                .WithOne(X => X.Day);
        }

        protected override string GetTableName()
        {
            return "ScheduleDays";
        }
    }
}
