using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails
{
	public class DayEventLookup : IMapWith<DayEvent>
	{
		public Guid Id { get; set; }

		public DayNumber DayNumber { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<DayEvent, DayEventLookup>();
		}
	}
}