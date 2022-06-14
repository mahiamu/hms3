using AutoMapper;
using HospitalManagementSystem.API.Dtos.PatientFiles;
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
    public class PatientFileController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientFileController> _logger;
        private readonly IMapper _mapper;

        public PatientFileController(
            IUnitOfWork unitOfWork,
            ILogger<PatientFileController> logger,
            IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPatientFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatientFiles()
        {
            try
            {
                var patientFiles = await _unitOfWork.PatientFiles.GetAll();
                var result = _mapper.Map<IList<PatientFilesDisplayDto>>(patientFiles);

                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in {nameof(GetPatientFiles)}");
                return StatusCode(500);
            }
        }



        [HttpGet("{id:int}", Name = "GetPatientFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatientFile(int id)
        {
            try
            {
                var patientFile = await _unitOfWork.PatientFiles.Get(at => at.Id == id);
                var result = _mapper.Map<PatientFilesDisplayDto > (patientFile);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetPatientFile) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreatePatientFile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePatientFile([FromBody] PatientFilesFormDto patientFileFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreatePatientFile) }");

                return BadRequest(ModelState);
            }

            try
            {
                var patientFile = _mapper.Map<PatientFile>(patientFileFormDto);
                await _unitOfWork.PatientFiles.Insert(patientFile);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPatientFile", new { id = patientFile.Id }, patientFile);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreatePatientFile) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdatePatientFile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePatientFile(int id, [FromBody] PatientFilesFormDto patientFileFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdatePatientFile) }");

                return BadRequest(ModelState);
            }

            try
            {
                var patientFile = await _unitOfWork.PatientFiles.Get(pf => pf.Id == id);

                if (patientFile == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdatePatientFile) }");

                    return BadRequest("Patient File not found");
                }

                _mapper.Map(patientFileFormDto, patientFile);

                _unitOfWork.PatientFiles.Update(patientFile);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdatePatientFile) }");

                return StatusCode(500);
            }

        }


        [HttpDelete("{id:int}", Name = "DeletePatientFile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePatientFile(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePatientFile) }");

                return BadRequest();
            }

            try
            {
                var patientFile= await _unitOfWork.PatientFiles.Get(pf => pf.Id == id);

                if (patientFile == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeletePatientFile) }");

                    return BadRequest("Patient File not found.");
                }

                await _unitOfWork.PatientFiles.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeletePatientFile) }");

                return StatusCode(500);
            }
        }
    }
}
