using System.Collections.Immutable;
using System.Reflection;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.Entities;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<ShoppingList> ShoppingLists { get; set; }
		public DbSet<ShoppingItem> ShoppingItems { get; set; }
		public DbSet<ItemCategory> ItemCategories { get; set; }
		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}
	}
}