using FluentValidation;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent
{
	public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
	{
		public CreateEventCommandValidator()
		{
			RuleFor(x => x.GroupId)
				.NotEqual(Guid.Empty);
			RuleFor(x => x.DayNumber)
				.NotNull();
			RuleFor(x => x.Begin)
				.NotNull();
			RuleFor(x => x.End)
				.NotNull();
			RuleFor(x => x.Address)
				.NotNull();
		}
	}
}
