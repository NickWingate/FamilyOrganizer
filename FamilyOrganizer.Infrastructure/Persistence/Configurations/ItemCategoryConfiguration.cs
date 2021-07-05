using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyOrganizer.Infrastructure.Persistence.Configurations
{
	public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
	{
		public void Configure(EntityTypeBuilder<ItemCategory> builder)
		{
			builder.Property(i => i.Name)
				.HasMaxLength(30)
				.IsRequired();
		}
	}
}