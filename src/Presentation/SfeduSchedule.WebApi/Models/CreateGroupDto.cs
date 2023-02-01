using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Groups.Commands.CreateGroup;

namespace SfeduSchedule.WebApi.Models;

public class CreateGroupDto : IMapWith<CreateGroupCommand>
{

    /// <summary>
    /// Имя группы
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// GUID факультета группы
    /// </summary>
    public Guid FacultyId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateGroupDto, CreateGroupCommand>();
    }
}