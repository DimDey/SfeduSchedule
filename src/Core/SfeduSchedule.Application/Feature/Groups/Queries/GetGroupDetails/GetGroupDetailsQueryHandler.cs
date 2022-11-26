using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Common.Exceptions;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsVm>
{
    private readonly IRepository<Group> _groupRepository;
    private readonly IMapper _mapper;
    public GetGroupDetailsQueryHandler(IRepository<Group> groupRepository, IMapper mapper)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    
    public async Task<GroupDetailsVm> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _groupRepository.GetByGuIdAsync(request.Id, cancellationToken);
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Group), request.Id);
        }

        return _mapper.Map<GroupDetailsVm>(entity);
    }
}