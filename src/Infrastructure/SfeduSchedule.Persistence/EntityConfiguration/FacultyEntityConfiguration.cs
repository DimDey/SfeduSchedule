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

			builder.HasMany(x => x.Groups)
				.WithOne(x => x.Faculty)
				.HasForeignKey(x => x.FacultyId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
