using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Features.Groups.Commands.UpdateGroup;

namespace SfeduSchedule.WebApi.Models;

public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
{
	/// <summary>
	/// GUID группы
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Новое имя группы
	/// </summary>
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>();
	}
}