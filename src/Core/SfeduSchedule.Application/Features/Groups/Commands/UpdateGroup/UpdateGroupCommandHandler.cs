using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
{
	private readonly IRepository<Group> _groupRepository;

	public UpdateGroupCommandHandler(IRepository<Group> repository)
	{
		_groupRepository = repository;
	}

	public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
	{
		var group = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);
		if (group == null || group.Id != request.Id)
		{
			throw new NotFoundException(nameof(Group), request.Id);
		}

		if (!string.IsNullOrEmpty(request.Name))
			group.Name = request.Name;

		if (group.FacultyId != Guid.Empty)
			group.FacultyId = request.FacultyId;

		await _groupRepository.UpdateAsync(group);
		return Unit.Value;
	}
}