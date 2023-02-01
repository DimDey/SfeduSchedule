using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetFacultyGroups;

public class GroupLookupDto : IMapWith<Group>
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Group, GroupLookupDto>();
	}
}