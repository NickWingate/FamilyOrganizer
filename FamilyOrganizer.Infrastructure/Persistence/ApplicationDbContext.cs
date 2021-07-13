using System;
using System.Collections.Immutable;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.Common;
using FamilyOrganizer.Domain.Entities;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly IDateTime _dateTimeProvider;
		public ApplicationDbContext(DbContextOptions options, IDateTime dateTimeProvider) : base(options)
		{
			_dateTimeProvider = dateTimeProvider;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			
			base.OnModelCreating(modelBuilder);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				// todo add CreatedBy and ModifiedBy
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.Created = _dateTimeProvider.Now;
						break;
					case EntityState.Modified:
						entry.Entity.LastModified = _dateTimeProvider.Now;
						break;
				}
			}
			return await base.SaveChangesAsync(cancellationToken);
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