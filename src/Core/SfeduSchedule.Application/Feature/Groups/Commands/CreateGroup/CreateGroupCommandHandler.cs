using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IRepository<Group> _groupRepository;
    public CreateGroupCommandHandler(IRepository<Group> repository) =>
        _groupRepository = repository;
    
    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group()
        {
            Id = Guid.NewGuid(),
            FacultyId = request.FacultyId,
            Name = request.Name,
            Schedules = new List<Schedule>()
        };

        await _groupRepository.AddAsync(group, cancellationToken);
        return group.Id;
    }
}