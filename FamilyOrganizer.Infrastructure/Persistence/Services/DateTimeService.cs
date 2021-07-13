using System;
using FamilyOrganizer.Application.Common.Interfaces;

namespace FamilyOrganizer.Infrastructure.Persistence.Services
{
	public class DateTimeService : IDateTime
	{
		public DateTime Now => DateTime.Now;
	}
}