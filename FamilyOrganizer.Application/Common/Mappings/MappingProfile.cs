using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Domain.Entities;
using FamilyOrganizer.Domain.ValueObjects;

namespace FamilyOrganizer.Application.Common.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ItemCategory, ItemCategoryDto>().ReverseMap();
			CreateMap<ShoppingItem, ShoppingItemDto>().ReverseMap();
			CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
		}
	}
}