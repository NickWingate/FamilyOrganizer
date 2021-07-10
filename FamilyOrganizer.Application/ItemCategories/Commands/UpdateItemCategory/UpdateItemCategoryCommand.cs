using System.Threading;
using System.Threading.Tasks;
using FamilyOrganizer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Application.ItemCategories.Commands.UpdateItemCategory
{
	public class UpdateItemCategoryCommand : IRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class UpdateItemCategoryCommandHandler : IRequestHandler<UpdateItemCategoryCommand>
	{
		private readonly IApplicationDbContext _context;

		public UpdateItemCategoryCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateItemCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _context.ItemCategories.FindAsync(request.Id);

			category.Name = request.Name;

			await _context.SaveChangesAsync(cancellationToken);
			
			return Unit.Value;
		}
	}
}