using AutoMapper;
using HospitalManagementSystem.API.Dtos.Specializations;
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
    public class SpecializationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SpecializationsController> _logger;
        private readonly IMapper _mapper;

        public SpecializationsController(
            IUnitOfWork unitOfWork,
            ILogger<SpecializationsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSpecializations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSpecializations()
        {
            try
            {
                var specializations = await _unitOfWork.Specializations.GetAll();
                var result = _mapper.Map<IList<SpecializationDisplayDto>>(specializations);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetSpecializations) }");

                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetSpecialization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSpecialization(int id)
        {
            try
            {
                var specialization = await _unitOfWork.Specializations.Get(s => s.Id == id);
                var result = _mapper.Map<SpecializationDisplayDto>(specialization);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetSpecialization) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateSpecialization")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSpecialization([FromBody] SpecializationFormDto specializationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateSpecialization) }");

                return BadRequest(ModelState);
            }

            try
            {
                var specialization = _mapper.Map<Specialization>(specializationFormDto);
                await _unitOfWork.Specializations.Insert(specialization);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetSpecialization", new { id = specialization.Id }, specialization);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateSpecialization) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateSpecialization")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSpecialization(int id, [FromBody] SpecializationFormDto specializationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateSpecialization) }");

                return BadRequest(ModelState);
            }

            try
            {
                var specialization = await _unitOfWork.Specializations.Get(s => s.Id == id);

                if (specialization == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateSpecialization) }");

                    return BadRequest("Specializations not found");
                }

                _mapper.Map(specializationFormDto, specialization);

                _unitOfWork.Specializations.Update(specialization);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateSpecialization) }");

                return StatusCode(500);
            }

        }


        [HttpDelete("{id:int}", Name = "DeleteSpecialization")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteSpecialization) }");

                return BadRequest();
            }

            try
            {
                var specialization = await _unitOfWork.Specializations.Get(s => s.Id == id);

                if (specialization == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteSpecialization) }");

                    return BadRequest("Specialization not found.");
                }

                await _unitOfWork.Specializations.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteSpecialization) }");

                return StatusCode(500);
            }
        }
    }
}
