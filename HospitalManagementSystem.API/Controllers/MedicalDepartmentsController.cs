using AutoMapper;
using HospitalManagementSystem.API.Dtos.MedicalDepartments;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalDepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MedicalDepartmentsController> _logger;
        private readonly IMapper _mapper;

        public MedicalDepartmentsController(
            IUnitOfWork unitOfWork,
            ILogger<MedicalDepartmentsController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMedicalDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicalDepartments()
        {
            try
            {
                var medicalDepartments = await _unitOfWork.MedicalDepartments.GetAll();
                var result = _mapper.Map<IList<MedicalDepartmentDisplayDto>>(medicalDepartments);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetMedicalDepartments) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetMedicalDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicalDepartment(int id)
        {
            try
            {
                var medicalDepartment = await _unitOfWork.MedicalDepartments.Get(at => at.Id == id);
                var result = _mapper.Map<MedicalDepartmentDisplayDto>(medicalDepartment);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetMedicalDepartment)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateMedicalDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMedicalDepartment([FromBody] MedicalDepartmentFormDto medicalDepartmentFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateMedicalDepartment) }");

                return BadRequest(ModelState);
            }
            try
            {
                var medicalDepartment = _mapper.Map<MedicalDepartment>(medicalDepartmentFormDto);
                await _unitOfWork.MedicalDepartments.Insert(medicalDepartment);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetMedicalDepartment", new { id = medicalDepartment.Id }, medicalDepartment);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateMedicalDepartment) }");

                return StatusCode(500);

            }
        }

        [HttpPut("{id:int}", Name = "UpdateMedicalDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMedicalDepartment(int id, [FromBody] MedicalDepartmentFormDto medicalDepartmentFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicalDepartment) }");

                return BadRequest(ModelState);
            }
            try
            {
                var medicalDepartment = await _unitOfWork.MedicalDepartments.Get(at => at.Id == id);

                if (medicalDepartment == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateMedicalDepartment) }");

                    return BadRequest("Medical Department not found");
                }

                _mapper.Map(medicalDepartmentFormDto, medicalDepartment);

                _unitOfWork.MedicalDepartments.Update(medicalDepartment);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateMedicalDepartment) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteMedicalDepartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMedicalDepartment(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteMedicalDepartment) }");

                return BadRequest();
            }

            try
            {
                var medicalDepartment = await _unitOfWork.MedicalDepartments.Get(at => at.Id == id);

                if (medicalDepartment == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteMedicalDepartment) }");

                    return BadRequest("Medical Department not found");
                }

                await _unitOfWork.MedicalDepartments.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteMedicalDepartment) }");

                return StatusCode(500);
            }
        }
    }
}
