using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.EntityConfiguration.Base;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
	public class GroupEntityConfiguration : BaseEntityConfiguration<Group>
	{
		public override void Configure(EntityTypeBuilder<Group> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).IsRequired();

			builder.HasMany(x => x.Events)
				.WithOne(x => x.Group)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
