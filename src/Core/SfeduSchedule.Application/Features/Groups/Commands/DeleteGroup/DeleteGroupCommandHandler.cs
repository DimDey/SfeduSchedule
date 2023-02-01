using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
{
	private readonly IRepository<Group> _groupRepository;

	public DeleteGroupCommandHandler(IRepository<Group> groupRepository)
	{
		_groupRepository = groupRepository;
	}

	public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
	{
		var entity = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);
		if (entity == null)
		{
			throw new NotFoundException(nameof(Group), request.Id);
		}

		await _groupRepository.DeleteAsync(entity, cancellationToken);

		return Unit.Value;

	}
}