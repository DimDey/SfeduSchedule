using MediatR;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQuery : IRequest<GroupDetailsVm>
{
    public Guid Id { get; set; }
}