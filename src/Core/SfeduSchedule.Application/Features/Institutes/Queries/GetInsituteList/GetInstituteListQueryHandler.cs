using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Queries.GetInsituteList;

public class GetInstituteListQueryHandler : IRequestHandler<GetInstituteListQuery, InstituteListVm>
{
	private readonly IRepository<Institute> _insituteRepository;
	private readonly IMapper _mapper;

	public GetInstituteListQueryHandler(IRepository<Institute> repository, IMapper mapper)
	{
		_insituteRepository = repository;
		_mapper = mapper;
	}

	public async Task<InstituteListVm> Handle(GetInstituteListQuery request, CancellationToken cancellationToken)
	{
		var instituteList = await _insituteRepository.ListAllQuery()
			.ProjectTo<InstituteLookupDto>(_mapper.ConfigurationProvider)
			.ToListAsync();

		return new InstituteListVm() { Institutes = instituteList };

	}
}