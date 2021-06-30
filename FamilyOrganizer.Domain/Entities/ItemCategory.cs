using System.Collections.Generic;
using FamilyOrganizer.Domain.Common;

namespace FamilyOrganizer.Domain.Entities
{
	public class ItemCategory : ValueObject
	{
		public ItemCategory(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Name;
		}
	}
}