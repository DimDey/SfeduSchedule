using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Institutes.Commands.UpdateInstitute;

namespace SfeduSchedule.WebApi.Models;

public class UpdateInstituteDto : IMapWith<UpdateInstituteCommand>
{
	/// <summary>
	/// GUID института
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Новое имя института
	/// </summary>
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateInstituteDto, UpdateInstituteCommand>();
	}
}