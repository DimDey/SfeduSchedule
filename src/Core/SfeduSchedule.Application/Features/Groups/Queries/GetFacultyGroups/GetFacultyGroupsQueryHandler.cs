using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SfeduSchedule.Application.Interfaces.Repository;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetFacultyGroups;
 
 public class GetFacultyGroupsQueryHandler : IRequestHandler<GetFacultyGroupsQuery, GroupsVm>
 {
     private readonly IGroupRepository _groupRepository;
     private readonly IMapper _mapper;
 
     public GetFacultyGroupsQueryHandler(IGroupRepository repository, IMapper mapper)
     {
         _groupRepository = repository;
         _mapper = mapper;
     }
     
     public async Task<GroupsVm> Handle(GetFacultyGroupsQuery request, CancellationToken cancellationToken)
     {
         var groupsQuery = await _groupRepository.FindWhere(x => x.FacultyId == request.FacultyId)
             .ProjectTo<GroupLookupDTO>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);

         return new GroupsVm { Groups = groupsQuery };

     }
 }