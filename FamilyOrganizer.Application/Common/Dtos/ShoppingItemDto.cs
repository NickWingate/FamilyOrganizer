using System.ComponentModel.DataAnnotations;
using FamilyOrganizer.Domain.Enums;
using FamilyOrganizer.Domain.ValueObjects;

namespace FamilyOrganizer.Application.Common.Dtos
{
	public class ShoppingItemDto
	{
		public int Id { get; set; }
		
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		
		[Required]
		public int Quantity { get; set; }
		
		[Required]
		public decimal UnitCost { get; set; }
		
		public ItemCategoryDto Category { get; set; }
		public ItemPriority Priority { get; set; }
	}
}