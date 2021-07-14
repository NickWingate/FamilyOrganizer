using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;

namespace FamilyOrganizer.Application.ItemCategories.Queries.GetItemCategoryById
{
	public class GetItemCategoryByIdQuery : IRequest<ItemCategoryDto>
	{
		public int Id { get; set; }

		public GetItemCategoryByIdQuery(int id)
		{
			Id = id;
		}
	}
	public class GetItemCategoryByIdQueryHandler : IRequestHandler<GetItemCategoryByIdQuery, ItemCategoryDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetItemCategoryByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ItemCategoryDto> Handle(GetItemCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var category = await _context.ItemCategories.FindAsync(new object[]{request.Id}, cancellationToken);
			
			var response = _mapper.Map<ItemCategoryDto>(category);
			
			return response;
		}
	}
}