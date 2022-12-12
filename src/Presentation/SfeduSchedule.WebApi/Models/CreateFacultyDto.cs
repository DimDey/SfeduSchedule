using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Faculties.Commands.CreateFaculty;

namespace SfeduSchedule.WebApi.Controllers;

public class CreateFacultyDto : IMapWith<CreateFacultyCommand>
{
    public string Name { get; set; }
    public Guid InstituteId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFacultyDto, CreateFacultyCommand>();
    }
}