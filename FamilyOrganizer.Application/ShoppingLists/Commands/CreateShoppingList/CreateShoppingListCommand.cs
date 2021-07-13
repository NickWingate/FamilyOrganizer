using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.Entities;
using MediatR;

namespace FamilyOrganizer.Application.ShoppingLists.Commands.CreateShoppingList
{
	public class CreateShoppingListCommand : IRequest<ShoppingList>
	{
		public string Name { get; set; }
	}

	public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, ShoppingList>
	{
		private readonly IApplicationDbContext _context;

		public CreateShoppingListCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ShoppingList> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
		{
			//todo add Auditable entity properties initialization
			var list = new ShoppingList()
			{
				Name = request.Name
			};
			//todo maybe change to .Add for optimisation (source:) https://stackoverflow.com/a/52318741
			await _context.ShoppingLists.AddAsync(list, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			// todo test list id is being set correctly
			return list;
		}
	}
}