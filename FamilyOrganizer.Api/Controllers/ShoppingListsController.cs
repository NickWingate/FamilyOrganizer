using System;
using System.Threading.Tasks;
using FamilyOrganizer.Application.ShoppingLists.Commands.CreateShoppingList;
using FamilyOrganizer.Application.ShoppingLists.Queries.GetShoppingLists;
using Microsoft.AspNetCore.Mvc;

namespace FamilyOrganizer.Api.Controllers
{
	public class ShoppingListsController : ApiControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetShoppingLists()
		{
			return Ok(await Mediator.Send(new GetShoppingListsQuery()));
		}

		[HttpPost]
		public async Task<IActionResult> CreateShoppingList(CreateShoppingListCommand command)
		{
			var shoppingList = await Mediator.Send(command);
			return Created(new Uri($"{Request.Path}/{shoppingList.Id}",UriKind.Relative), shoppingList);
		}
	}
}