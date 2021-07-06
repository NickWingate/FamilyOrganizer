using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Domain.Entities;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		public DbSet<ShoppingList> ShoppingLists { get; set; }
		public DbSet<ShoppingItem> ShoppingItems { get; set; }
		public DbSet<ItemCategory> ItemCategories { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
		Task<int> SaveChangesAsync();
	}
}