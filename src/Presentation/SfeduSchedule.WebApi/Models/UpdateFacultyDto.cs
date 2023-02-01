using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Faculties.Commands.UpdateFaculty;

namespace SfeduSchedule.WebApi.Controllers;

public class UpdateFacultyDto : IMapWith<UpdateFacultyCommand>
{
	/// <summary>
	/// GUID факультета
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Новое имя факультета
	/// </summary>
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateFacultyDto, UpdateFacultyCommand>();
	}
}