using MediatR;

namespace SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;

public class UpdateGroupCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
}