using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.ItemCategories.Queries.GetItemCategories
{
	public class GetItemCategoriesQuery : IRequest<IList<ItemCategoryDto>>
	{
		
	}
	public class  GetItemCategoriesQueryHandler : IRequestHandler<GetItemCategoriesQuery, IList<ItemCategoryDto>>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetItemCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IList<ItemCategoryDto>> Handle(GetItemCategoriesQuery request, CancellationToken cancellationToken)
		{
			var categories = await _context.ItemCategories.ToListAsync(cancellationToken: cancellationToken);
			var response = _mapper.Map<IList<ItemCategoryDto>>(categories);
			return response;
		}
	}
}