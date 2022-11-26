using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.ViewModels
{
    public class DayViewModel : IMapWith<Day>
    {
        public Guid Id { get; set; }
        public IEnumerable<CoupleModel> Couples { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Day, DayViewModel>();
        }
    }
}
