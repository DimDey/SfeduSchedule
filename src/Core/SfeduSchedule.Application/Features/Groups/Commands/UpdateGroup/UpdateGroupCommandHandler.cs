using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
{
    private readonly IGroupRepository _groupRepository;

    public UpdateGroupCommandHandler(IGroupRepository repository)
    {
        _groupRepository = repository;
    }
    
    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);
        group.Name = request.Name;
        group.FacultyId = request.FacultyId;
        await _groupRepository.UpdateAsync(group);
        return Unit.Value;
    }
}