using MediatR;

namespace SfeduSchedule.Application.Features.Groups.Commands.DeleteGroup;

public class DeleteGroupCommand : IRequest<Unit>
{
    public Guid Id { get; set; }    
}
