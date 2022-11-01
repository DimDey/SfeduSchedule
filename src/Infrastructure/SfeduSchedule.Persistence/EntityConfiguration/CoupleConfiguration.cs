using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class CoupleConfiguration : BaseEntityConfiguration<Couple>
    {
        protected override void BuildConfig(EntityTypeBuilder<Couple> builder)
        {
            builder.HasOne(x => x.Day)
                .WithMany(x => x.Couples);

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

        protected override string GetTableName()
        {
            return "DayCouples";
        }
    }
}
