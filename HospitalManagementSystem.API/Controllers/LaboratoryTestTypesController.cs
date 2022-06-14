using AutoMapper;
using HospitalManagementSystem.API.Dtos.LaboratoryTestTypes;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LaboratoryTestTypesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<LaboratoryTestTypesController> _logger;
		private readonly IMapper _mapper;

		public LaboratoryTestTypesController(
			IUnitOfWork unitOfWork,
			ILogger<LaboratoryTestTypesController> logger,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetLaboratoryTestTypes")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetLaboratoryTestTypes()
		{
			try
			{
				var laboratoryTestType = await _unitOfWork.LaboratoryTestTypes.GetAll();
				var result = _mapper.Map<IList<LaboratoryTestTypeDisplayDto>>(laboratoryTestType);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetLaboratoryTestTypes) }");

				return StatusCode(500);
			}
		}

		[HttpGet("{id:int}", Name = "GetLaboratoryTestType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetLaboratoryTestType(int id)
		{
			try
			{
				var laboratoryTestType = await _unitOfWork.LaboratoryTestTypes.Get(ltt => ltt.Id == id);
				var result = _mapper.Map<LaboratoryTestTypeDisplayDto>(laboratoryTestType);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetLaboratoryTestType) }");

				return StatusCode(500);
			}
		}

		[HttpPost(Name = "CreateLaboratoryTestType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateLaboratoryTestType([FromBody] LaboratoryTestTypeFormDto laboratoryTestTypeFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Post attempt made at { nameof(CreateLaboratoryTestType) }");

				return BadRequest(ModelState);
			}
			try
			{
				var laboratoryTestType = _mapper.Map<LaboratoryTestType>(laboratoryTestTypeFormDto);
				await _unitOfWork.LaboratoryTestTypes.Insert(laboratoryTestType);
				await _unitOfWork.Save();

				return CreatedAtRoute("GetLaboratoryTestType", new { id = laboratoryTestType.Id }, laboratoryTestType);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(CreateLaboratoryTestType) }");

				return StatusCode(500);
			}
		}

		[HttpPut("{id:int}", Name = "UpdateLaboratoryTestType")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateLaboratoryTestType(int id, [FromBody] LaboratoryTestTypeFormDto laboratoryTestTypeFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Update attempt at { nameof(UpdateLaboratoryTestType) }");

				return BadRequest(ModelState);
			}
			try
			{
				var laboratoryTestType = await _unitOfWork.LaboratoryTestTypes.Get(ltt => ltt.Id == id);

				if (laboratoryTestType == null)
				{
					_logger.LogError($"Invalid Update attempt at { nameof(UpdateLaboratoryTestType) }");

					return BadRequest("LaboratoryTestType not found");
				}

				_mapper.Map(laboratoryTestTypeFormDto, laboratoryTestType);

				_unitOfWork.LaboratoryTestTypes.Update(laboratoryTestType);

				await _unitOfWork.Save();

				return NoContent();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(UpdateLaboratoryTestType) }");

				return StatusCode(500);
			}
		}

		[HttpDelete("{id:int}", Name = "DeleteLaboratoryTestType")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteLaboratoryTestType(int id)
		{
			if (id < 1)
			{
				_logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteLaboratoryTestType) }");

				return BadRequest();
			}

			try
			{
				var laboratoryTestType = await _unitOfWork.LaboratoryTestTypes.Get(ltt => ltt.Id == id);

				if (laboratoryTestType == null)
				{
					_logger.LogError($"Invalid Delete attempt at { nameof(DeleteLaboratoryTestType) }");

					return BadRequest("LaboratoryTestType not found");
				}

				await _unitOfWork.LaboratoryTestTypes.Delete(id);

				await _unitOfWork.Save();

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(DeleteLaboratoryTestType) }");

				return StatusCode(500);
			}
		}
	}
}
