using FamilyOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
			
		}

		public DbSet<ShoppingList> ShoppingLists { get; set; }
		public DbSet<ShoppingItem> ShoppingItems { get; set; }
		public DbSet<ItemCategory> ItemCategories { get; set; }
	}
}