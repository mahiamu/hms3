using AutoMapper;
using HospitalManagementSystem.API.Dtos.Patients;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientsController> _logger;
        private readonly IMapper _mapper;

        public PatientsController(IMapper mapper, ILogger<PatientsController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name ="GetPatients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _unitOfWork.Patients.GetAll();
                var result = _mapper.Map<IList<PatientDisplayDto>>(patients);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetPatients)}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatient(int id)
        {
            try
            {
                var patient = await _unitOfWork.Patients.Get(p => p.Id == id);
                var result = _mapper.Map<PatientDisplayDto>(patient);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetPatient)}");
                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreatePatient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePatient([FromBody] PatientFormDto patientFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in {nameof(CreatePatient)}");
                
                return BadRequest(ModelState);
            }

            try
            {
                var patient = _mapper.Map<Patient>(patientFormDto);
                await _unitOfWork.Patients.Insert(patient);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPatient", new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(CreatePatient)}");
                
                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientFormDto patientFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdatePatient) }");

                return BadRequest(ModelState);
            }

            try
            {
                var patient = await _unitOfWork.Patients.Get(p => p.Id == id);

                if (patient == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdatePatient) }");

                    return BadRequest("Admission type not found");
                }

                _mapper.Map(patientFormDto, patient);

                _unitOfWork.Patients.Update(patient);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdatePatient) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePatient) }");

                return BadRequest();
            }

            try
            {
                var patient = await _unitOfWork.Patients.Get(at => at.Id == id);

                if (patient == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeletePatient) }");

                    return BadRequest("Medical Department not found");
                }

                await _unitOfWork.Patients.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeletePatient) }");

                return StatusCode(500);
            }
        }
    }
}
