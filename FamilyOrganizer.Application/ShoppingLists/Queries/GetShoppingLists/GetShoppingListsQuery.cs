using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Application.ShoppingItems.Queries.GetShoppingItems;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.ShoppingLists.Queries.GetShoppingLists
{
	public class GetShoppingListsQuery : IRequest<IList<ShoppingListDto>>
	{
		
	}

	public class GetShoppingListQueryHandler : IRequestHandler<GetShoppingListsQuery, IList<ShoppingListDto>>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetShoppingListQueryHandler(
			IMapper mapper, IApplicationDbContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<IList<ShoppingListDto>> Handle(GetShoppingListsQuery request, CancellationToken cancellationToken)
		{
			var lists = await _context.ShoppingLists.ToListAsync();
			var response = _mapper.Map<IList<ShoppingListDto>>(lists);
			return response;
		}
	}
}