using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.ViewModels
{
    public class ScheduleViewModel : IMapWith<Schedule>
    {
        public Guid Id { get; set; }
        public ICollection<DayViewModel> Days { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Schedule, ScheduleViewModel>();
        }
    }
}
