using AutoMapper;

namespace SfeduSchedule.WebApi.Common.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TimeSpan, string>()
                .ConstructUsing(x => x.ToString(@"hh\:mm"));

        }
    }
}
