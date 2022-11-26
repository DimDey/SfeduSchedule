using MediatR;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQuery : IRequest<GroupDetailsVm>
{
    public Guid Id { get; set; }
}