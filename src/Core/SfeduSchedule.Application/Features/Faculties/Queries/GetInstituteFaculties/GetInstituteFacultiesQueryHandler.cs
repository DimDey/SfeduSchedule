using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository.Base;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesQueryHandler : IRequestHandler<GetInstituteFacultiesQuery, FacultyListVm>
{
	private readonly IRepository<Faculty> _facultyRepository;
	private readonly IMapper _mapper;

	public GetInstituteFacultiesQueryHandler(IRepository<Faculty> repository, IMapper mapper)
	{
		_facultyRepository = repository;
		_mapper = mapper;
	}

	public async Task<FacultyListVm> Handle(GetInstituteFacultiesQuery request, CancellationToken cancellationToken)
	{
		var facultyQuery = await _facultyRepository
			.FindWhere(x => x.InstituteId == request.InstituteId)
			.ProjectTo<FacultyLookupDto>(_mapper.ConfigurationProvider)
			.ToListAsync();

		return new FacultyListVm() { Faculties = facultyQuery };
	}
}