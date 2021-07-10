using System.Reflection;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyOrganizer.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			
			return services;
		}
	}
}