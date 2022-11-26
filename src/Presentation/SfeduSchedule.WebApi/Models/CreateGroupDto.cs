using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Feature.Groups.Commands.CreateGroup;

namespace SfeduSchedule.WebApi.Models;

public class CreateGroupDto : IMapWith<CreateGroupCommand>
{
    public string Name { get; set; }
    public Guid FacultyId { get; set; } // TODO: Remove facultyGuid and add mapping from user identity
}