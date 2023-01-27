using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.DayEvents.Queries.GetEventDetails
{
	public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
	{
		private readonly IRepository<DayEvent> _dayEvents;
		private readonly IMapper _mapper;

		public GetEventDetailsQueryHandler(IRepository<DayEvent> dayEvents, IMapper mapper)
		{
			_dayEvents = dayEvents;
			_mapper = mapper;
		}

		public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
		{
			var entity = await _dayEvents.GetByGuIdAsync(request.Id);
			if (entity == null || entity.Id != request.Id) 
				throw new NotFoundException(nameof(DayEvent), request.Id);
			
			return _mapper.Map<EventDetailsVm>(entity);
		}
	}
}
