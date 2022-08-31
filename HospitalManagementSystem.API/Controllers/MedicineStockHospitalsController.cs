using AutoMapper;
using HospitalManagementSystem.API.Dtos.MedicineStockHospitals;
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
	public class MedicineStockHospitalsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<MedicineStockHospitalsController> _logger;
		private readonly IMapper _mapper;

		public MedicineStockHospitalsController(
			IUnitOfWork unitOfWork,
			ILogger<MedicineStockHospitalsController> logger,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetMedicineStockHospitals")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMedicineStockHospitals()
		{
			try
			{
				var medicinestockhospital = await _unitOfWork.MedicineStockHospitals.GetAll();
				var result = _mapper.Map<IList<MedicineStockHospitalDisplayDto>>(medicinestockhospital);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetMedicineStockHospitals) }");

				return StatusCode(500);
			}
		}

		[HttpGet("{id:int}", Name = "GetMedicineStockHospital")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMedicineStockHospital(int id)
		{
			try
			{
				var medicinestockhospital = await _unitOfWork.MedicineStockHospitals.Get(cn => cn.Id == id);
				var result = _mapper.Map<MedicineStockHospitalDisplayDto>(medicinestockhospital);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetMedicineStockHospital) }");

				return StatusCode(500);
			}
		}

		[HttpPost(Name = "CreateMedicineStockHospital")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateMedicineStockHospital([FromBody] MedicineStockHospitalFormDto medicinestockhospitalFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Post attempt made at {nameof(CreateMedicineStockHospital) }");

				return BadRequest(ModelState);
			}
			try
			{
				var medicinestockhospital = _mapper.Map<MedicineStockHospital>(medicinestockhospitalFormDto); 
				await _unitOfWork.MedicineStockHospitals.Insert(medicinestockhospital);
				await _unitOfWork.Save();

				return CreatedAtRoute("GetMedicineStockHospital", new { id = medicinestockhospital.Id }, medicinestockhospital);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(CreateMedicineStockHospital) }");

				return StatusCode(500);
			}
		}

		[HttpPut("{id:int}", Name = "UpdateMedicineStockHospital")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateMedicineStockHospital(int id, [FromBody] MedicineStockHospitalFormDto MedicineStockHospitalFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicineStockHospital) }");

				return BadRequest(ModelState);
			}
			try
			{
				var medicinestockhospital = await _unitOfWork.MedicineStockHospitals.Get(m => m.Id == id);

				if (medicinestockhospital == null)
				{
					_logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicineStockHospital) }");

					return BadRequest("MedicineStockHospital not found");
				}

				_mapper.Map(MedicineStockHospitalFormDto, medicinestockhospital);

				_unitOfWork.MedicineStockHospitals.Update(medicinestockhospital);

				await _unitOfWork.Save();

				return NoContent();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(UpdateMedicineStockHospital) }");

				return StatusCode(500);
			}
		}

		[HttpDelete("{id:int}", Name = "DeleteMedicineStockHospital")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteMedicineStockHospital(int id)
		{
			if (id < 1)
			{
				_logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteMedicineStockHospital) }");

				return BadRequest();
			}

			try
			{
				var medicinestockhospital = await _unitOfWork.MedicineStockHospitals.Get(m => m.Id == id);

				if (medicinestockhospital == null)
				{
					_logger.LogError($"Invalid Delete attempt at { nameof(DeleteMedicineStockHospital) }");

					return BadRequest("MedicineStockHospital not found");
				}

				await _unitOfWork.MedicineStockHospitals.Delete(id);

				await _unitOfWork.Save();

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(DeleteMedicineStockHospital) }");

				return StatusCode(500);
			}
		}
	}
}
