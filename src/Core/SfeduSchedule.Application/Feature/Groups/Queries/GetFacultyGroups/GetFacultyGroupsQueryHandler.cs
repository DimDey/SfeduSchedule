using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Interfaces.Repository;
using SfeduSchedule.Application.ViewModels;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetFacultyGroups
{
    public class GetFacultyGroupsQueryHandler : IRequestHandler<GetFacultyGroupsQuery, List<FacultyGroupVm>>
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;
        public GetFacultyGroupsQueryHandler(IRepository<Group> groupRepository, IMapper mapper)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }
        public async Task<List<FacultyGroupVm>> Handle(GetFacultyGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.FindAsync(x => x.FacultyId == request.FacultyId, cancellationToken);

            return _mapper.Map<List<FacultyGroupVm>>(groups);
        }
    }
}
