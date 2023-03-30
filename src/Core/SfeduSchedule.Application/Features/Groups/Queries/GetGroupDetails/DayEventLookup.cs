using AutoMapper;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.Groups.Queries.GetGroupDetails
{
	public class DayEventLookup : IMapWith<DayEvent>
	{
		public Guid Id { get; set; }

		public DayNumber DayNumber { get; set; }

		public string Begin { get; set; }

		public string End { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string ClassRoom { get; set; }

		public string Teacher { get; set; }

		public bool? OnEven { get; set; }

		public int? SubGroup { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<DayEvent, DayEventLookup>();
		}
	}
}