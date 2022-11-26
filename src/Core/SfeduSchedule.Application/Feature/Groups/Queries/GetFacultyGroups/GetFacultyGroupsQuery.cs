using MediatR;
using SfeduSchedule.Application.ViewModels;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetFacultyGroups
{
    public class GetFacultyGroupsQuery : IRequest<List<FacultyGroupVm>>
    {
        public Guid FacultyId { get; set; }
    }
}
