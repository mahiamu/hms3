﻿using AutoMapper;
using HospitalManagementSystem.API.Dtos.Medicines;
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
	public class MedicinesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<MedicinesController> _logger;
		private readonly IMapper _mapper;

		public MedicinesController(
			IUnitOfWork unitOfWork,
			ILogger<MedicinesController> logger,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetMedicines")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMedicines()
		{
			try
			{
				var medicine = await _unitOfWork.Medicines.GetAll();
				var result = _mapper.Map<IList<MedicineDisplayDto>>(medicine);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetMedicines) }");

				return StatusCode(500);
			}
		}

		[HttpGet("{id:int}", Name = "GetMedicine")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMedicine(int id)
		{
			try
			{
				var medicine = await _unitOfWork.Medicines.Get(cn => cn.Id == id);
				var result = _mapper.Map<MedicineDisplayDto>(medicine);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetMedicine) }");

				return StatusCode(500);
			}
		}

		[HttpPost(Name = "CreateMedicine")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateMedicine([FromBody] MedicineFormDto medicineFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Post attempt made at { nameof(CreateMedicine) }");

				return BadRequest(ModelState);
			}
			try
			{
				var medicine = _mapper.Map<Medicine>(medicineFormDto);
				await _unitOfWork.Medicines.Insert(medicine);
				await _unitOfWork.Save();

				return CreatedAtRoute("GetMedicine", new { id = medicine.Id }, medicine);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(CreateMedicine) }");

				return StatusCode(500);
			}
		}

		[HttpPut("{id:int}", Name = "UpdateMedicine")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateMedicine(int id, [FromBody] MedicineFormDto medicineFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicine) }");

				return BadRequest(ModelState);
			}
			try
			{
				var medicine = await _unitOfWork.Medicines.Get(m => m.Id == id);

				if (medicine == null)
				{
					_logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicine) }");

					return BadRequest("Medicine not found");
				}

				_mapper.Map(medicineFormDto, medicine);

				_unitOfWork.Medicines.Update(medicine);

				await _unitOfWork.Save();

				return NoContent();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(UpdateMedicine) }");

				return StatusCode(500);
			}
		}

		[HttpDelete("{id:int}", Name = "DeleteMedicine")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteMedicine(int id)
		{
			if (id < 1)
			{
				_logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteMedicine) }");

				return BadRequest();
			}

			try
			{
				var medicine = await _unitOfWork.Medicines.Get(m => m.Id == id);

				if (medicine == null)
				{
					_logger.LogError($"Invalid Delete attempt at { nameof(DeleteMedicine) }");

					return BadRequest("Medicine not found");
				}

				await _unitOfWork.Medicines.Delete(id);

				await _unitOfWork.Save();

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(DeleteMedicine) }");

				return StatusCode(500);
			}
		}
	}
}
