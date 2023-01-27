using MediatR;

namespace SfeduSchedule.Application.Features.DayEvents.Queries.GetEventDetails
{
	public class GetEventDetailsQuery : IRequest<EventDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
