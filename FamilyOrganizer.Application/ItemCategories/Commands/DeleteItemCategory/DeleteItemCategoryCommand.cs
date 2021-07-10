using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;

namespace FamilyOrganizer.Application.ItemCategories.Commands.DeleteItemCategory
{
	public class DeleteItemCategoryCommand : IRequest
	{
		public int Id { get; set; }

		public DeleteItemCategoryCommand(int id)
		{
			Id = id;
		}
	}
	public class DeleteItemCategoryCommandHandler : IRequestHandler<DeleteItemCategoryCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeleteItemCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteItemCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _context.ItemCategories.FindAsync(request.Id);
			_context.ItemCategories.Remove(category);
			await _context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}