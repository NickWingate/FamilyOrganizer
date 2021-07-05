using System;
using System.Collections.Generic;
using System.Linq;
using FamilyOrganizer.Domain.Common;

namespace FamilyOrganizer.Domain.Entities
{
	public class ShoppingList : AuditableEntity
	{
		public int Id { get; set; }
		public List<ShoppingItem> Items { get; set; } = new List<ShoppingItem>();
		public string Name { get; set; }
		public decimal TotalCost => CalculateTotalCost();

		private decimal CalculateTotalCost()
		{
			return Items.Sum(item => item.TotalCost);
		}
	}
}