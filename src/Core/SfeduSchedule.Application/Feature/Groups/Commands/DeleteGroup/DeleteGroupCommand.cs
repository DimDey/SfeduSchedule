using MediatR;

namespace SfeduSchedule.Application.Feature.Groups.Commands.DeleteGroup;

public class DeleteGroupCommand : IRequest
{
    public Guid Id { get; set; }
}