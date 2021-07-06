using System.ComponentModel.DataAnnotations;

namespace FamilyOrganizer.Application.Common.Dtos
{
	public class ItemCategoryDto
	{
		public int Id { get; set; }
		
		[Required]
		[MaxLength(30)]
		public string Name { get; set; }
	}
}