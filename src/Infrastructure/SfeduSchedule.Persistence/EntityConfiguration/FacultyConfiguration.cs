using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class FacultyConfiguration : BaseEntityConfiguration<Faculty>
    {
        protected override void BuildConfig(EntityTypeBuilder<Faculty> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.Institute)
                .WithMany(x => x.Faculties);

            builder.HasMany(x => x.Groups)
                .WithOne(x => x.Faculty);
        }

        protected override string GetTableName()
        {
            throw new NotImplementedException();
        }
    }
}
