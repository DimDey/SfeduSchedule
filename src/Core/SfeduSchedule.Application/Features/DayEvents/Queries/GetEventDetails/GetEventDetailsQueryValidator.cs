using FluentValidation;

namespace SfeduSchedule.Application.Features.DayEvents.Queries.GetEventDetails
{
	public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
	{
		public GetEventDetailsQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEqual(Guid.Empty);
		}
	}
}
