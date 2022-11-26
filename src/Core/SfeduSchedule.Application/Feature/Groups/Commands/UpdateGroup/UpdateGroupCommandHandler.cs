using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly IRepository<Group> _groupRepository;
    
    public UpdateGroupCommandHandler(IRepository<Group> groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var updateEntity = new Group()
        {
            Id = request.Id,
            FacultyId = request.FacultyId,
            Name = request.Name
        };
        await _groupRepository.UpdateAsync(updateEntity, cancellationToken);
        
        return Unit.Value;
    }
}