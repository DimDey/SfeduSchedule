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
    public class FacultyEntityConfiguration : BaseEntityConfiguration<Faculty>
    {
        public override void Configure(EntityTypeBuilder<Faculty> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.Institute)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x => x.InstituteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Groups)
                .WithOne(x => x.Faculty)
                .HasForeignKey(x => x.FacultyId);
        }
    }
}
