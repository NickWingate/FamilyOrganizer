using System.Linq;
using FamilyOrganizer.Domain.Entities;

namespace FamilyOrganizer.Domain.Extensions
{
	public static class ShoppingListExtensions 
	{
		public static decimal TotalCost(this ShoppingList list)
		{
			return list.Items.Sum(item => item.TotalCost());
		}
	}
}