using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.Common.Repositories
{
	public class ItemCategoryRepository : IRepositoryBase<ItemCategory>
	{
		private readonly IApplicationDbContext _context;

		public ItemCategoryRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IList<ItemCategory>> FindAll()
		{
			return await _context.ItemCategories.ToListAsync();
		}

		public async Task<ItemCategory> FindById(int id)
		{
			return await _context.ItemCategories.FindAsync(id);
		}

		public async Task<bool> Exists(int id)
		{
			return await _context.ItemCategories.AnyAsync(i => i.Id == id);
		}

		public async Task<bool> Create(ItemCategory entity)
		{
			await _context.ItemCategories.AddAsync(entity);
			return await Save();
		}

		public async Task<bool> Update(ItemCategory entity)
		{
			_context.ItemCategories.Update(entity);
			return await Save();
		}

		public async Task<bool> Delete(ItemCategory entity)
		{
			_context.ItemCategories.Remove(entity);
			return await Save();		
		}

		public async Task<bool> Save()
		{
			var changes = await _context.SaveChangesAsync();
			return changes > 0;
		}
	}
}