using FamilyOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyOrganizer.Infrastructure.Persistence.Configurations
{
	public class ShoppingItemConfiguration : IEntityTypeConfiguration<ShoppingItem>
	{
		public void Configure(EntityTypeBuilder<ShoppingItem> builder)
		{
			builder.Property(i => i.Name)
				.HasMaxLength(50)
				.IsRequired();
			builder.Property(i => i.Quantity)
				.IsRequired();
			builder.Property(i => i.UnitCost)
				.IsRequired();
		}
	}
}