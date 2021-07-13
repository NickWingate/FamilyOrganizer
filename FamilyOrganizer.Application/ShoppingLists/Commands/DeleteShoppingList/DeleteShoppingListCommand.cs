using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;

namespace FamilyOrganizer.Application.ShoppingLists.Commands.DeleteShoppingList
{
	public class DeleteShoppingListCommand : IRequest
	{
		public DeleteShoppingListCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
	
	public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeleteShoppingListCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
		{
			var list = await _context.ShoppingLists.FindAsync(request.Id);

			_context.ShoppingLists.Remove(list);

			await _context.SaveChangesAsync(cancellationToken);
			
			return Unit.Value;
		}
	}
}