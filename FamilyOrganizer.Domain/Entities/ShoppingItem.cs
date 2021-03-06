using FamilyOrganizer.Domain.Common;
using FamilyOrganizer.Domain.Enums;
using FamilyOrganizer.Domain.ValueObjects;

namespace FamilyOrganizer.Domain.Entities
{
	public class ShoppingItem : AuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitCost { get; set; }
		public ItemCategory Category { get; set; }
		public ItemPriority Priority { get; set; }
	}
}