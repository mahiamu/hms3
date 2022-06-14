using AutoMapper;
using HospitalManagementSystem.API.Dtos.Nurses;
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
    public class NursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NursesController> _logger;
        private readonly IMapper _mapper;

        public NursesController(
            IUnitOfWork unitOfWork,
            ILogger<NursesController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetNurses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNurses()
        {
            try
            {
                var nurses = await _unitOfWork.Nurses.GetAll();
                var result = _mapper.Map<IList<NurseDisplayDto>>(nurses);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetNurses) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNurse(int id)
        {
            try
            {
                var nurse = await _unitOfWork.Nurses.Get(n => n.Id == id);
                var result = _mapper.Map<NurseDisplayDto>(nurse);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetNurse)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNurse([FromBody] NurseFormDto nurseFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateNurse) }");

                return BadRequest(ModelState);
            }
            try
            {
                var nurse = _mapper.Map<Nurse>(nurseFormDto);
                await _unitOfWork.Nurses.Insert(nurse);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetNurse", new { id = nurse.Id }, nurse);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateNurse) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateNurse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateNurse(int id, [FromBody] NurseFormDto nurseFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateNurse) }");

                return BadRequest(ModelState);
            }
            try
            {
                var nurse = await _unitOfWork.Nurses.Get(n => n.Id == id);

                if (nurse == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateNurse) }");

                    return BadRequest("Nurse not found");
                }

                _mapper.Map(nurseFormDto, nurse);

                _unitOfWork.Nurses.Update(nurse);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateNurse) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteNurse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteNurse) }");

                return BadRequest();
            }

            try
            {
                var nurse = await _unitOfWork.Nurses.Get(n => n.Id == id);

                if (nurse == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteNurse) }");

                    return BadRequest("Nurse not found");
                }

                await _unitOfWork.Nurses.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteNurse) }");

                return StatusCode(500);
            }
        }
    }
}
