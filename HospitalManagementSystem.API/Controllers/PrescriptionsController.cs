using AutoMapper;
using HospitalManagementSystem.API.Dtos.Prescriptions;
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
    public class PrescriptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PrescriptionsController> _logger;
        private readonly IMapper _mapper;

        public PrescriptionsController(
            IUnitOfWork unitOfWork,
            ILogger<PrescriptionsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPrescriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPrescriptions()
        {
            try
            {
                var prescriptions = await _unitOfWork.Prescriptions.GetAll();
                var result = _mapper.Map<IList<PrescriptionDisplayDto>>(prescriptions);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPrescriptions) }");

                return StatusCode(500);

            }
        }

        [HttpGet("{id:int}", Name = "GetPrescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPrescription(int id)
        {
            try
            {
                var prescription = await _unitOfWork.Prescriptions.Get(pr => pr.Id == id);
                var result = _mapper.Map<PrescriptionDisplayDto>(prescription);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetPrescription) }");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreatePrescription")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionFormDto prescriptionFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreatePrescription) }");

                return BadRequest(ModelState);
            }

            try
            {
                var prescription = _mapper.Map<Prescription>(prescriptionFormDto);
                await _unitOfWork.Prescriptions.Insert(prescription);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPrescription", new { id = prescription.Id }, prescription);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreatePrescription) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdatePrescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] PrescriptionFormDto prescriptionFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdatePrescription) }");

                return BadRequest(ModelState);
            }

            try
            {
                var prescription = await _unitOfWork.Prescriptions.Get(pr => pr.Id == id);

                if (prescription == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdatePrescription) }");

                    return BadRequest("Admission type not found");
                }
                _mapper.Map(prescriptionFormDto, prescription);

                _unitOfWork.Prescriptions.Update(prescription);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdatePrescription) }");

                return StatusCode(500);
            }
        }
        [HttpDelete("{id:int}", Name = "DeletePrescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePrescription) }");

                return BadRequest();
            }

            try
            {
                var prescription = await _unitOfWork.Prescriptions.Get(pr => pr.Id == id);

                if (prescription == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeletePrescription)}");

                    return BadRequest("Prescription not found.");
                }

                await _unitOfWork.Prescriptions.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeletePrescription) }");

                    return StatusCode(500);
            }
        }
    }
}