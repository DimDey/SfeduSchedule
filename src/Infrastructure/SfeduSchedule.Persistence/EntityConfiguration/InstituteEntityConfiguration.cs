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
    public class InstituteEntityConfiguration : BaseEntityConfiguration<Institute>
    {
        public override void Configure(EntityTypeBuilder<Institute> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Faculties)
                .WithOne();
        }
    }
}
