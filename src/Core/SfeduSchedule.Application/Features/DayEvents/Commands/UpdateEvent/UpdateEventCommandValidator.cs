using FluentValidation;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.UpdateEvent
{
	public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
	{
		public UpdateEventCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEqual(Guid.Empty);
		}
	}
}
