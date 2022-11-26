using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.ViewModels
{
    public class CoupleModel : IMapWith<Couple>
    {
        public Guid Id { get; set; }
        public Guid DayId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string ClassRoom { get; set; }
        public string Teacher { get; set; }
        public bool? OnEven { get; set; }
        public int? SubGroup { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Couple, CoupleModel>();
        }
    }
}
