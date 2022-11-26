using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.EntityConfiguration.Base;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class DayEntityConfiguration : BaseEntityConfiguration<Day>
    {
        public override void Configure(EntityTypeBuilder<Day> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Couples)
                .WithOne(x => x.Day)
                .HasForeignKey(x => x.DayId);
        }
    }
}
