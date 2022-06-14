using AutoMapper;
using HospitalManagementSystem.API.Dtos.Holidays;
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
    public class HolidaysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HolidaysController> _logger;
        private readonly IMapper _mapper;

        public HolidaysController(
            IUnitOfWork unitOfWork,
            ILogger<HolidaysController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHolidays()
        {
            try
            {
                var holidays = await _unitOfWork.Holidays.GetAll();
                var result = _mapper.Map<IList<HolidayDisplayDto>>(holidays);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetHolidays) }");

                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetHoliday")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHoliday(int id)
        {
            try
            {
                var holiday = await _unitOfWork.Holidays.Get(at => at.Id == id);
                var result = _mapper.Map<HolidayDisplayDto>(holiday);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetHoliday) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateHoliday")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHoliday([FromBody] HolidayFormDto holidayFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateHoliday) }");

                return BadRequest(ModelState);
            }

            try
            {
                var holiday = _mapper.Map<Holiday>(holidayFormDto);
                await _unitOfWork.Holidays.Insert(holiday);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetHoliday", new { id = holiday.Id }, holiday);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateHoliday) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateHoliday")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHoliday(int id, [FromBody] HolidayFormDto holidayFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateHoliday) }");

                return BadRequest(ModelState);
            }

            try
            {
                var holiday = await _unitOfWork.Holidays.Get(at => at.Id == id);

                if (holiday == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateHoliday) }");

                    return BadRequest("Holiday not found");
                }

                _mapper.Map(holidayFormDto, holiday);

                _unitOfWork.Holidays.Update(holiday);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateHoliday) }");

                return StatusCode(500);
            }

        }


        [HttpDelete("{id:int}", Name = "DeleteHoliday")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteHoliday) }");

                return BadRequest();
            }

            try
            {
                var holiday = await _unitOfWork.Holidays.Get(at => at.Id == id);

                if (holiday == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteHoliday) }");

                    return BadRequest("Holiday not found.");
                }

                await _unitOfWork.Holidays.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteHoliday) }");

                return StatusCode(500);
            }
        }
    }
}
