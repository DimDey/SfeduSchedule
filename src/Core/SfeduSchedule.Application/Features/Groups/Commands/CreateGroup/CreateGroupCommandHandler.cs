using MediatR;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
	private readonly IRepository<Group> _groupRepository;

	public CreateGroupCommandHandler(IRepository<Group> groupRepository)
	{
		_groupRepository = groupRepository;
	}


	public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
	{
		var group = new Group()
		{
			Id = Guid.NewGuid(),
			Name = request.Name
		};

		await _groupRepository.AddAsync(group, cancellationToken);
		return group.Id;
	}
}