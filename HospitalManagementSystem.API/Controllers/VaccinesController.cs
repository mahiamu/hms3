using AutoMapper;
using HospitalManagementSystem.API.Dtos.Vaccines;
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
    public class VaccinesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VaccinesController> _logger;
        private readonly IMapper _mapper;
        public VaccinesController(
           IUnitOfWork unitOfWork,
           ILogger<VaccinesController> logger,
           IMapper mapper
           )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetVaccines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVaccines()
        {
            try
            {
                var vaccines = await _unitOfWork.Vaccines.GetAll();
                var result = _mapper.Map<IList<VaccineDisplayDto>>(vaccines);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetVaccines) }");

                return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetVaccine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVaccine(int id)
        {
            try
            {
                var vaccine = await _unitOfWork.Vaccines.Get(v => v.Id == id);
                var result = _mapper.Map<VaccineDisplayDto>(vaccine);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetVaccine)}");

                return StatusCode(500);
            }
        }
        [HttpPost(Name = "CreateVaccine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateVaccine([FromBody] VaccineFormDto vaccineFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateVaccine) }");

                return BadRequest(ModelState);
            }
            try
            {
                var vaccine = _mapper.Map<Vaccine>(vaccineFormDto);
                await _unitOfWork.Vaccines.Insert(vaccine);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAppointmentDuration", new { id = vaccine.Id }, vaccine);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateVaccine) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateVaccine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateVaccine(int id, [FromBody] VaccineFormDto vaccineFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateVaccine) }");

                return BadRequest(ModelState);
            }
            try
            {
                var vaccine = await _unitOfWork.Vaccines.Get(v => v.Id == id);

                if (vaccine == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateVaccine) }");

                    return BadRequest("Vaccine not found");
                }

                _mapper.Map(vaccineFormDto, vaccine);

                _unitOfWork.Vaccines.Update(vaccine);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateVaccine) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteVaccine")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteVaccine) }");

                return BadRequest();
            }

            try
            {
                var vaccine = await _unitOfWork.Vaccines.Get(v => v.Id == id);

                if (vaccine == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteVaccine) }");

                    return BadRequest("Vaccine not found");
                }

                await _unitOfWork.Vaccines.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteVaccine) }");

                return StatusCode(500);
            }
        }
    }
}
