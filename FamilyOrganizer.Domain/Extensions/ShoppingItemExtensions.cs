using FamilyOrganizer.Domain.Entities;

namespace FamilyOrganizer.Domain.Extensions
{
	public static class ShoppingItemExtensions
	{
		public static decimal TotalCost(this ShoppingItem item)
		{
			return item.UnitCost * item.Quantity;
		}
	}
}