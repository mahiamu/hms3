using AutoMapper;
using HospitalManagementSystem.API.Dtos.Pharmacists;
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
    public class PharmacistsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PharmacistsController> _logger;
        private readonly IMapper _mapper;

        public PharmacistsController(
            IUnitOfWork unitOfWork,
            ILogger<PharmacistsController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPharmacists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPharmacists()
        {
            try
            {
                var pharmacists = await _unitOfWork.Pharmacists.GetAll();
                var result = _mapper.Map<IList<PharmacistDisplayDto>>(pharmacists);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPharmacists) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetPharmacist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPharmacist(int id)
        {
            try
            {
                var pharmacist = await _unitOfWork.Pharmacists.Get(p => p.Id == id);
                var result = _mapper.Map<PharmacistDisplayDto>(pharmacist);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPharmacist)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreatePharmacist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePharmacist([FromBody] PharmacistFormDto pharmacistFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreatePharmacist) }");

                return BadRequest(ModelState);
            }
            try
            {
                var pharmacist = _mapper.Map<Pharmacist>(pharmacistFormDto);
                await _unitOfWork.Pharmacists.Insert(pharmacist);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPharmacist", new { id = pharmacist.Id }, pharmacist);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreatePharmacist) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdatePharmacist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePharmacist(int id, [FromBody] PharmacistFormDto pharmacistFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdatePharmacist) }");

                return BadRequest(ModelState);
            }
            try
            {
                var pharmacist = await _unitOfWork.Pharmacists.Get(p => p.Id == id);

                if (pharmacist == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdatePharmacist) }");

                    return BadRequest("Pharmacist not found");
                }

                _mapper.Map(pharmacistFormDto, pharmacist);

                _unitOfWork.Pharmacists.Update(pharmacist);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdatePharmacist) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePharmacist")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePharmacist(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePharmacist) }");

                return BadRequest();
            }

            try
            {
                var pharmacist = await _unitOfWork.Pharmacists.Get(p => p.Id == id);

                if (pharmacist == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeletePharmacist) }");

                    return BadRequest("Pharmacist not found");
                }

                await _unitOfWork.Pharmacists.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeletePharmacist) }");

                return StatusCode(500);
            }
        }
    }
}
