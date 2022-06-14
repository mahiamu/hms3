using AutoMapper;
using HospitalManagementSystem.API.Dtos.AdmissionTypes;
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
    public class AdmissionTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdmissionTypesController> _logger;
        private readonly IMapper _mapper;

        public AdmissionTypesController(
            IUnitOfWork unitOfWork, 
            ILogger<AdmissionTypesController> logger, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAdmissionTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdmissionTypes()
        {
            try
            {
                var admissionTypes = await _unitOfWork.AdmissionTypes.GetAll();
                var result = _mapper.Map<IList<AdmissionTypeDisplayDto>>(admissionTypes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetAdmissionTypes) }");
                
                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetAdmissionType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdmissionType(int id)
        {
            try
            {
                var admissionType = await _unitOfWork.AdmissionTypes.Get(at => at.Id == id);
                var result = _mapper.Map<AdmissionTypeDisplayDto>(admissionType);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetAdmissionType) }");
                
                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateAdmissionType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAdmissionType([FromBody] AdmissionTypeFormDto admissionTypeFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateAdmissionType) }");

                return BadRequest(ModelState);
            }

            try
            {
                var admissionType = _mapper.Map<AdmissionType>(admissionTypeFormDto);
                await _unitOfWork.AdmissionTypes.Insert(admissionType);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAdmissionType", new { id = admissionType.Id }, admissionType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateAdmissionType) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateAdmissionType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAdmissionType(int id, [FromBody] AdmissionTypeFormDto admissionTypeFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateAdmissionType) }");

                return BadRequest(ModelState);
            }

            try
            {
                var admissionType = await _unitOfWork.AdmissionTypes.Get(at => at.Id == id);

                if(admissionType == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateAdmissionType) }");

                    return BadRequest("Admission type not found");
                }

                _mapper.Map(admissionTypeFormDto, admissionType);

                _unitOfWork.AdmissionTypes.Update(admissionType);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateAdmissionType) }");

                return StatusCode(500);
            }

        }


        [HttpDelete("{id:int}", Name = "DeleteAdmissionType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAdmissionType(int id)
        {
            if(id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteAdmissionType) }");

                return BadRequest();
            }

            try
            {
                var admissionType = await _unitOfWork.AdmissionTypes.Get(at => at.Id == id);

                if(admissionType == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteAdmissionType) }");
                    
                    return BadRequest("Admission type not found.");
                }

                await _unitOfWork.AdmissionTypes.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteAdmissionType) }");

                return StatusCode(500);
            }
        }
    }
}
