﻿using AutoMapper;
using MediatR;
using SfeduSchedule.Application.Common.Mappings;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Application.Features.DayEvents.Commands.CreateEvent
{
	public class CreateEventCommand : IRequest<Guid>, IMapWith<DayEvent>
	{
		public Guid GroupId { get; set; }

		public DayNumber DayNumber { get; set; }

		public TimeSpan Begin { get; set; }

		public TimeSpan End { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string ClassRoom { get; set; }

		public string Teacher { get; set; }

		public bool? OnEven { get; set; }

		public int? SubGroup { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateEventCommand, DayEvent>();
		}
	}
}
