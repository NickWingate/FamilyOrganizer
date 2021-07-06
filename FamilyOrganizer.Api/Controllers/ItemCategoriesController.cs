using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FamilyOrganizer.Api.Contracts;
using FamilyOrganizer.Application.Common.Dtos;
using FamilyOrganizer.Application.Common.Interfaces;
using FamilyOrganizer.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemCategoriesController : ControllerBase
	{
		private readonly IRepositoryBase<ItemCategory> _repository;
		private readonly ILoggerService _logger;
		private readonly IMapper _mapper;

		public ItemCategoriesController(
			ILoggerService logger,
			IMapper mapper, 
			IRepositoryBase<ItemCategory> repository)
		{
			_logger = logger;
			_mapper = mapper;
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{ 
			var categories = await _repository.FindAll();
			var response = _mapper.Map<IList<ItemCategoryDto>>(categories);
			return Ok(response);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var category = await _repository.FindById(id);
			var categoryDto = _mapper.Map<ItemCategoryDto>(category);
			return Ok(categoryDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ItemCategoryDto categoryDto)
		{
			if (categoryDto is null || !ModelState.IsValid)
			{
				return BadRequest(categoryDto);
			}
			
			categoryDto.Id = 0;
			var category = _mapper.Map<ItemCategory>(categoryDto);

			var createdSuccessfully = await _repository.Create(category);;

			if (!createdSuccessfully)
			{
				return InternalError("Failed to create item category");
			}
			
			return Created(new Uri($"{Request.Path}/{category.Id}", UriKind.Relative), category);
		}
		
		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id,[FromBody] ItemCategoryDto categoryDto)
		{
			var updatedCategory = _mapper.Map<ItemCategory>(categoryDto);
			updatedCategory.Id = id;
			var isSuccess = await _repository.Update(updatedCategory);
			if (!isSuccess)
			{
				return InternalError("Update Failed");
			}

			return NoContent();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var categoryToDelete = await _repository.FindById(id);
			var isSuccess = await _repository.Delete(categoryToDelete);
			if (!isSuccess)
			{
				return InternalError("Update Failed");
			}

			return NoContent();
		}
		
		
		
		private string GetControllerActionNames()
		{
			var controller = ControllerContext.ActionDescriptor.ControllerName;
			var action = ControllerContext.ActionDescriptor.ActionName;

			return $"{controller} - {action}";
		}
		
		private ObjectResult InternalError(string logMessage)
		{
			_logger.LogError(logMessage);
			// 500 - Internal Server Error
			return StatusCode(500, "Something went wrong. Please contact the Administrator");
		}
	}
}