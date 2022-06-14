using AutoMapper;
using HospitalManagementSystem.API.Dtos.AppointmentDurations;
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
    public class AppointmentDurationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AppointmentDurationsController> _logger;
        private readonly IMapper _mapper;

        public AppointmentDurationsController(
            IUnitOfWork unitOfWork,
            ILogger<AppointmentDurationsController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAppointmentDurations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAppointmentDurations()
        {
            try
            {
                var appointmentDurations = await _unitOfWork.AppointmentDurations.GetAll();
                var result = _mapper.Map<IList<AppointmentDurationDisplayDto>>(appointmentDurations);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetAppointmentDurations) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetAppointmentDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAppointmentDuration(int id)
        {
            try
            {
                var appointmentDuration = await _unitOfWork.AppointmentDurations.Get(ad => ad.Id == id);
                var result = _mapper.Map<AppointmentDurationDisplayDto>(appointmentDuration);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetAppointmentDuration)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateAppointmentDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAppointmentDuration([FromBody] AppointmentDurationFormDto appointmentDurationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateAppointmentDuration) }");

                return BadRequest(ModelState);
            }
            try
            {
                var appointmentDuration = _mapper.Map<AppointmentDuration>(appointmentDurationFormDto);
                await _unitOfWork.AppointmentDurations.Insert(appointmentDuration);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAppointmentDuration", new { id = appointmentDuration.Id }, appointmentDuration);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateAppointmentDuration) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateAppointmentDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAppointmentDuration(int id, [FromBody] AppointmentDurationFormDto appointmentDurationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateAppointmentDuration) }");

                return BadRequest(ModelState);
            }
            try
            {
                var appointmentDuration = await _unitOfWork.AppointmentDurations.Get(ad => ad.Id == id);

                if (appointmentDuration == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateAppointmentDuration) }");

                    return BadRequest("Appointment duration not found");
                }

                _mapper.Map(appointmentDurationFormDto, appointmentDuration);

                _unitOfWork.AppointmentDurations.Update(appointmentDuration);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateAppointmentDuration) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteAppointmentDuration")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAppointmentDuration(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteAppointmentDuration) }");

                return BadRequest();
            }

            try
            {
                var appointmentDuration = await _unitOfWork.AppointmentDurations.Get(ad => ad.Id == id);

                if (appointmentDuration == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteAppointmentDuration) }");

                    return BadRequest("Appointment duration not found");
                }

                await _unitOfWork.AppointmentDurations.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteAppointmentDuration) }");

                return StatusCode(500);
            }
        }
    }
}
