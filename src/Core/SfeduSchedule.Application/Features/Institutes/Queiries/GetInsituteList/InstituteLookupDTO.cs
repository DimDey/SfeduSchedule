using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Institutes.Queiries.GetInsituteList;

public class InstituteLookupDTO : IMapWith<Institute>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Institute, InstituteLookupDTO>();
    }
}