using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Api.Contracts;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Application.ItemCategories.Commands.CreateItemCategory;
using FamilyOrganizer.Application.ItemCategories.Commands.DeleteItemCategory;
using FamilyOrganizer.Application.ItemCategories.Commands.UpdateItemCategory;
using FamilyOrganizer.Application.ItemCategories.Queries.GetItemCategories;
using FamilyOrganizer.Application.ItemCategories.Queries.GetItemCategoryById;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Api.Controllers
{
	public class ItemCategoriesController : ApiControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			return Ok(await Mediator.Send(new GetItemCategoriesQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			return Ok(await Mediator.Send(new GetItemCategoryByIdQuery(id)));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateItemCategoryCommand command)
		{
			var category = await Mediator.Send(command);
			
			return Created(new Uri($"{Request.Path}/{category.Id}", UriKind.Relative), category);
		}
		
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateItemCategoryCommand command)
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
			await Mediator.Send(new DeleteItemCategoryCommand(id));

			return NoContent();
		}
	}
}