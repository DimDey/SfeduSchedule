using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class InstituteConfiguration : BaseEntityConfiguration<Institute>
    {
        protected override void BuildConfig(EntityTypeBuilder<Institute> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            
            builder.HasMany(x => x.Faculties)
                .WithOne(x => x.Institute);
        }

        protected override string GetTableName()
        {
            return "Institutes";
        }
    }
}
