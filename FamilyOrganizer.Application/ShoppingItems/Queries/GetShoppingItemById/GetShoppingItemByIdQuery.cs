using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;

namespace FamilyOrganizer.Application.ShoppingItems.Queries.GetShoppingItemById
{
	public class GetShoppingItemByIdQuery : IRequest<ShoppingItemDto>
	{
		public GetShoppingItemByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
	
	public class GetShoppingItemsByIdQueryHandler : IRequestHandler<GetShoppingItemByIdQuery, ShoppingItemDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetShoppingItemsByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<ShoppingItemDto> Handle(GetShoppingItemByIdQuery request, CancellationToken cancellationToken)
		{
			var item = await _context.ShoppingItems.FindAsync(
				new object[]{request.Id}, cancellationToken);

			var response = _mapper.Map<ShoppingItemDto>(item);

			return response;
		}
	}
}