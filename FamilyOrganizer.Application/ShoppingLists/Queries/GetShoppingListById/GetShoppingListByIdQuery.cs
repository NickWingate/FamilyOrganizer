using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;

namespace FamilyOrganizer.Application.ShoppingLists.Queries.GetShoppingListById
{
	public class GetShoppingListByIdQuery : IRequest<ShoppingListDto>
	{
		public GetShoppingListByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
	
	public class GetShoppingListByIdQueryHandler : IRequestHandler<GetShoppingListByIdQuery, ShoppingListDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetShoppingListByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ShoppingListDto> Handle(GetShoppingListByIdQuery request, CancellationToken cancellationToken)
		{
			var list = await _context.ShoppingLists.FindAsync(
				new object[]{request.Id}, cancellationToken);

			var response = _mapper.Map<ShoppingListDto>(list);

			return response;
		}
	}
}