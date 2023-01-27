using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.UpdateEvent
{
	public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
	{
		private readonly IRepository<DayEvent> _dayEvents;
		private readonly IMapper _mapper;

		public UpdateEventCommandHandler(IRepository<DayEvent> dayEvents, IMapper mapper)
		{
			_dayEvents = dayEvents;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dayEvents.GetByGuIdAsync(request.Id);
			if (entity == null || entity.Id != request.Id)
				throw new NotFoundException(nameof(DayEvent), request.Id);

			_mapper.Map(request, entity);
			await _dayEvents.UpdateAsync(entity);

			return Unit.Value;
		}
	}
}
