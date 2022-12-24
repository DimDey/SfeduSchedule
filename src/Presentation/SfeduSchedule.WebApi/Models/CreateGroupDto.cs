using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;

namespace SfeduSchedule.WebApi.Models;

public class CreateGroupDto : IMapWith<CreateGroupCommand>
{
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
    public Guid ScheduleId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateGroupDto, CreateGroupCommand>();
    }
}