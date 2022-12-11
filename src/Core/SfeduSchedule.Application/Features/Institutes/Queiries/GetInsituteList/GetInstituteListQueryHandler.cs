using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Institutes.Queiries.GetInsituteList;

public class GetInstituteListQueryHandler : IRequestHandler<GetInstituteListQuery, InstituteListVm>
{
    private readonly IInsituteRepository _insituteRepository;
    private readonly IMapper _mapper;

    public GetInstituteListQueryHandler(IInsituteRepository repository, IMapper mapper)
    {
        _insituteRepository = repository;
        _mapper = mapper;
    }
    
    public async Task<InstituteListVm> Handle(GetInstituteListQuery request, CancellationToken cancellationToken)
    {
        var instituteList = await _insituteRepository.ListAllQuery()
            .ProjectTo<InstituteLookupDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new InstituteListVm() { Institutes = instituteList };

    }
}