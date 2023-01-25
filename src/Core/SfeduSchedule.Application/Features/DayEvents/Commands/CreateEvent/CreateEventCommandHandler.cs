using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent
{
	public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
	{
		private readonly IRepository<DayEvent> _events;
		private readonly IMapper _mapper;

		public CreateEventCommandHandler(IRepository<DayEvent> events, IMapper mapper)
		{
			_events = events;
			_mapper = mapper;
		}

		public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<DayEvent>(request);
			if (entity == null)
			{
				throw new ArgumentException(nameof(DayEvent));
			}

			await _events.UpdateAsync(entity, cancellationToken);

			return entity.Id;
		}
	}
}
