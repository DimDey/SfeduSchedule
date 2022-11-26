using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Application.Feature.Groups.Commands.UpdateGroup;

namespace SfeduSchedule.WebApi.Models;
public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid FacultyId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>()
            .ForMember(x => x.Id, opt =>
                opt.MapFrom(x => x.Id))
            .ForMember(x => x.Name, opt =>
                opt.MapFrom(x => x.Name))
            .ForMember(x => x.FacultyId, opt =>
                opt.MapFrom(x => x.FacultyId));
    }
}