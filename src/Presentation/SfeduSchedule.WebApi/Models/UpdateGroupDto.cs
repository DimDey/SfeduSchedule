using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;

namespace SfeduSchedule.WebApi.Models;
public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
}