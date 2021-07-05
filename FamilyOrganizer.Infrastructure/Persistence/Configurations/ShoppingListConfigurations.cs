using FamilyOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyOrganizer.Infrastructure.Persistence.Configurations
{
	public class ShoppingListConfigurations : IEntityTypeConfiguration<ShoppingList>
	{
		public void Configure(EntityTypeBuilder<ShoppingList> builder)
		{
			builder.Property(i => i.Name)
				.HasMaxLength(50)
				.IsRequired();
		}
	}
}