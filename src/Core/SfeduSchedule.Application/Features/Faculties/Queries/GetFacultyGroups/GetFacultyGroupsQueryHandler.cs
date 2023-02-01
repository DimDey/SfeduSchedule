using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetFacultyGroups;

public class GetFacultyGroupsQueryHandler : IRequestHandler<GetFacultyGroupsQuery, GroupsVm>
{
	private readonly IRepository<Group> _groupRepository;
	private readonly IMapper _mapper;

	public GetFacultyGroupsQueryHandler(IRepository<Group> repository, IMapper mapper)
	{
		_groupRepository = repository;
		_mapper = mapper;
	}

	public async Task<GroupsVm> Handle(GetFacultyGroupsQuery request, CancellationToken cancellationToken)
	{
		var groupsQuery = await _groupRepository.FindWhere(x => x.FacultyId == request.FacultyId)
			.ProjectTo<GroupLookupDto>(_mapper.ConfigurationProvider)
			.ToListAsync(cancellationToken);

		return new GroupsVm { Groups = groupsQuery };
	}
}