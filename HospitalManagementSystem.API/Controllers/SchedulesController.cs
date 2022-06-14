using AutoMapper;
using HospitalManagementSystem.API.Dtos.Schedules;
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
	public class SchedulesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<SchedulesController> _logger;
		private readonly IMapper _mapper;

		public SchedulesController(
			IUnitOfWork unitOfWork,
			ILogger<SchedulesController> logger,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetSchedules")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetSchedules()
		{
			try
			{
				var schedule = await _unitOfWork.Schedules.GetAll();
				var result = _mapper.Map<IList<ScheduleDisplayDto>>(schedule);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetSchedules) }");

				return StatusCode(500);
			}
		}

		[HttpGet("{id:int}", Name = "GetSchedule")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetSchedule(int id)
		{
			try
			{
				var schedule = await _unitOfWork.Schedules.Get(cn => cn.Id == id);
				var result = _mapper.Map<ScheduleDisplayDto>(schedule);

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(GetSchedule) }");

				return StatusCode(500);
			}
		}

		[HttpPost(Name = "CreateSchedule")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateSchedule([FromBody] ScheduleFormDto scheduleFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Post attempt made at { nameof(CreateSchedule) }");

				return BadRequest(ModelState);
			}
			try
			{
				var schedule = _mapper.Map<Schedule>(scheduleFormDto);
				await _unitOfWork.Schedules.Insert(schedule);
				await _unitOfWork.Save();

				return CreatedAtRoute("GetSchedule", new { id = schedule.Id }, schedule);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong in { nameof(CreateSchedule) }");

				return StatusCode(500);
			}
		}

		[HttpPut("{id:int}", Name = "UpdateSchedule")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleFormDto scheduleFormDto)
		{
			if (!ModelState.IsValid)
			{
				_logger.LogError($"Invalid Update attempt at { nameof(UpdateSchedule) }");

				return BadRequest(ModelState);
			}
			try
			{
				var schedule = await _unitOfWork.Schedules.Get(cn => cn.Id == id);

				if (schedule == null)
				{
					_logger.LogError($"Invalid Update attempt at { nameof(UpdateSchedule) }");

					return BadRequest("Schedule not found");
				}

				_mapper.Map(scheduleFormDto, schedule);

				_unitOfWork.Schedules.Update(schedule);

				await _unitOfWork.Save();

				return NoContent();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(UpdateSchedule) }");

				return StatusCode(500);
			}
		}

		[HttpDelete("{id:int}", Name = "DeleteSchedule")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteSchedule(int id)
		{
			if (id < 1)
			{
				_logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteSchedule) }");

				return BadRequest();
			}

			try
			{
				var schedule = await _unitOfWork.Schedules.Get(cn => cn.Id == id);

				if (schedule == null)
				{
					_logger.LogError($"Invalid Delete attempt at { nameof(DeleteSchedule) }");

					return BadRequest("Schedule not found");
				}

				await _unitOfWork.Schedules.Delete(id);

				await _unitOfWork.Save();

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong at { nameof(DeleteSchedule) }");

				return StatusCode(500);
			}
		}
	}
}
