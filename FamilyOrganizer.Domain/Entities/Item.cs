using FamilyOrganizer.Domain.Common;
using FamilyOrganizer.Domain.Enums;

namespace FamilyOrganizer.Domain.Entities
{
	public class Item : AuditableEntity
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitCost { get; set; }
		public decimal TotalCost { get; set; }
		public ItemCategory Category { get; set; }
		public ItemPriority Priority { get; set; }
	}
}