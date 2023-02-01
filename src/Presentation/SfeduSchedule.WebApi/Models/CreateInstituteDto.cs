using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Institutes.Commands.CreateInstitute;

namespace SfeduSchedule.WebApi.Models;

public class CreateInstituteDto : IMapWith<CreateInstituteCommand>
{
	/// <summary>
	/// Имя института
	/// </summary>
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateInstituteDto, CreateInstituteCommand>();
	}
}