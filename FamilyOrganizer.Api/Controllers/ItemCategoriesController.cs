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

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ItemCategoryDto categoryDto)
		{
			categoryDto.Id = 0;
			if (categoryDto is null || !ModelState.IsValid)
			{
				return BadRequest(categoryDto);
			}

			var category = _mapper.Map<ItemCategory>(categoryDto);

			var createdSuccessfully = await _repository.Create(category);;

			if (!createdSuccessfully)
			{
				return InternalError("Failed to create item category");
			}
			
			return Created(new Uri($"{Request.Path}/{category.Id}", UriKind.Relative), category);
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