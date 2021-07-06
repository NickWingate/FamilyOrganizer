using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FamilyOrganizer.Domain.Entities;

namespace FamilyOrganizer.Application.Common.Dtos
{
	public class ShoppingListDto
	{
		public int Id { get; set; }
		public List<ShoppingItemDto> Items { get; set; }
		
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}