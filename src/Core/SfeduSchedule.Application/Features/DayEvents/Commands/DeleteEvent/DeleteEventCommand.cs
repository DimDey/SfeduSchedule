using FluentValidation;
using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.DeleteEvent
{
	public class DeleteEventCommand : IRequest
	{
		public Guid Id { get; set; }
	}

	public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
	{
		private readonly IRepository<DayEvent> _events;

		public DeleteEventCommandHandler(IRepository<DayEvent> events)
		{
			_events = events;
		}

		public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			var entity = await _events.GetByGuIdAsync(request.Id);
			if (entity == null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(DayEvent), request.Id);
			}

			await _events.DeleteAsync(entity);

			return Unit.Value;
		}
	}

	public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
	{
		public DeleteEventCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEqual(Guid.Empty);
		}
	}
}
