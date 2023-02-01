using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Faculties.Queries.GetInstituteFaculties;

public class FacultyLookupDto : IMapWith<Faculty>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public Guid InstituteId { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Faculty, FacultyLookupDto>();
    }
}