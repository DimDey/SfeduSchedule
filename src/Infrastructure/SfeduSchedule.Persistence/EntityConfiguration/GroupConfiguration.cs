using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public class GroupConfiguration : BaseEntityConfiguration<Group>
    {
        protected override void BuildConfig(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.Faculty)
                .WithMany(x => x.Groups);

            builder.HasOne(x => x.Schedule)
                .WithOne(x => x.Group);
        }

        protected override string GetTableName()
        {
            return "Groups";
        }
    }
}
