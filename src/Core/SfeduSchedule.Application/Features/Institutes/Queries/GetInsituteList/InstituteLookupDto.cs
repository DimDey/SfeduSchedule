using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Queries.GetInsituteList;

public class InstituteLookupDto : IMapWith<Institute>
{
	public Guid Id { get; set; }
	public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Institute, InstituteLookupDto>();
	}
}