using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;
using SfeduSchedule.Persistence.EntityConfiguration.Base;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
	public class EventEntityConfiguration : BaseEntityConfiguration<DayEvent>
	{
		public override void Configure(EntityTypeBuilder<DayEvent> builder)
		{
			base.Configure(builder);

			builder.Property(x => x.DayNumber)
				.IsRequired();

			builder.Property(x => x.Begin)
				.IsRequired();

			builder.Property(x => x.Description)
				.HasMaxLength(20);

			builder.Property(x => x.Address)
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