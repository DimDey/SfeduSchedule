using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Feature.Groups.Queries.GetFacultyGroups;

public class FacultyGroupVm : IMapWith<Group>
{
    public Guid Id { get; set; }
    public Guid FacultyId { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Group, FacultyGroupVm>();
    }
}