using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsVm>
{
	private readonly IRepository<Group> _groupRepository;
	private readonly IMapper _mapper;

	public GetGroupDetailsQueryHandler(IRepository<Group> repository, IMapper mapper)
	{
		_groupRepository = repository;
		_mapper = mapper;
	}

	public async Task<GroupDetailsVm> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
	{
		var entity = await _groupRepository.GetByGuIdAsync(request.Id);

		return _mapper.Map<GroupDetailsVm>(entity);
	}
}