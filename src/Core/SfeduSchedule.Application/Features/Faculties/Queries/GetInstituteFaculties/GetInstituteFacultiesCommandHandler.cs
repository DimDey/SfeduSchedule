using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class GetInstituteFacultiesCommandHandler : IRequestHandler<GetInstituteFacultiesCommand, FacultyListVm>
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;

    public GetInstituteFacultiesCommandHandler(IFacultyRepository repository, IMapper mapper)
    {
        _facultyRepository = repository;
        _mapper = mapper;
    }
    
    public async Task<FacultyListVm> Handle(GetInstituteFacultiesCommand request, CancellationToken cancellationToken)
    {
        var facultyQuery = await _facultyRepository
            .FindWhere(x => x.InstituteId == request.InstituteId)
            .ProjectTo<FacultyLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new FacultyListVm() { Faculties = facultyQuery };
    }
}