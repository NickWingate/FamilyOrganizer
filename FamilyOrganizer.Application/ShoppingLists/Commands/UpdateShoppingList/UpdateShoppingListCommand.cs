using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.ShoppingLists.Commands.UpdateShoppingList
{
	public class UpdateShoppingListCommand : IRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand>
	{
		private readonly IApplicationDbContext _context;

		public UpdateShoppingListCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
		{
			var list = await _context.ShoppingLists.FindAsync(request.Id);

			list.Name = request.Name;

			await _context.SaveChangesAsync(cancellationToken);
			
			return Unit.Value;
		}
	}
}