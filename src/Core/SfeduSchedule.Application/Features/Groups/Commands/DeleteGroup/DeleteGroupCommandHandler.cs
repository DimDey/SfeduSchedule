using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
{
    private readonly IGroupRepository _groupRepository;
    
    public DeleteGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);

        await _groupRepository.DeleteAsync(entity, cancellationToken);

        return Unit.Value;

    }
}