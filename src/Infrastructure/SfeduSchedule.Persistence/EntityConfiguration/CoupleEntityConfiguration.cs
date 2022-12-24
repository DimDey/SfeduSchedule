using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.EntityConfiguration.Base;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class CoupleEntityConfiguration : BaseEntityConfiguration<Couple>
    {
        public override void Configure(EntityTypeBuilder<Couple> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Number)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Building)
                .IsRequired();

            builder.Property(x => x.ClassRoom)
                .IsRequired();

            builder.Property(x => x.Teacher)
                .IsRequired();

            builder.Property(x => x.OnEven);
            builder.Property(x => x.SubGroup);
        }
    }
}
