using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.ValueObjects;
using MediatR;

namespace FamilyOrganizer.Application.ItemCategories.Commands.CreateItemCategory
{
	public class CreateItemCategoryCommand : IRequest<ItemCategory>
	{
		public string Name { get; set; }
	}
	public class CreateItemCategoryCommandHandler : IRequestHandler<CreateItemCategoryCommand, ItemCategory>
	{
		private readonly IApplicationDbContext _context;

		public CreateItemCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ItemCategory> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = new ItemCategory(request.Name);
			await _context.ItemCategories.AddAsync(category, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			return category;
		}
	}
}