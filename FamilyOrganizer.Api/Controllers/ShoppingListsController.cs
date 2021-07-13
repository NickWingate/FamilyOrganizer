using System;
using System.Threading.Tasks;
using FamilyOrganizer.Application.ShoppingLists.Commands.CreateShoppingList;
using FamilyOrganizer.Application.ShoppingLists.Commands.DeleteShoppingList;
using FamilyOrganizer.Application.ShoppingLists.Commands.UpdateShoppingList;
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

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateShoppingListCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			await Mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await Mediator.Send(new DeleteShoppingListCommand(id));

			return NoContent();
		}
	}
}