using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IRepository<Group> _groupRepository;
    public DeleteGroupCommandHandler(IRepository<Group> repository) =>
        _groupRepository = repository;
    
    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Group), request.Id);
        }

        await _groupRepository.DeleteAsync(entity, cancellationToken);
        return Unit.Value;
    }
}