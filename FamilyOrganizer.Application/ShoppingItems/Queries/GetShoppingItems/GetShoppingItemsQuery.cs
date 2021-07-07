using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.ShoppingItems.Queries.GetShoppingItems
{
	public class GetShoppingItemsQuery : IRequest<IList<ShoppingItemDto>>
	{
		
	}

	public class GetShoppingItemQueryHandler : IRequestHandler<GetShoppingItemsQuery, IList<ShoppingItemDto>>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetShoppingItemQueryHandler(
			IApplicationDbContext context, 
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IList<ShoppingItemDto>> Handle(GetShoppingItemsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}