using System.Reflection;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Application.Common.Repositories;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyOrganizer.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped<IRepositoryBase<ItemCategory>, ItemCategoryRepository>();

			return services;
		}
	}
}