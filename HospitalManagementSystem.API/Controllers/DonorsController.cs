using AutoMapper;
using HospitalManagementSystem.API.Dtos.Donors;
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
    public class DonorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DonorsController> _logger;
        private readonly IMapper _mapper;

        public DonorsController(
            IUnitOfWork unitOfWork,
            ILogger<DonorsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetDonors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDonors()
        {
            try
            {
                var donors = await _unitOfWork.Donors.GetAll();
                var result = _mapper.Map<IList<DonorDisplayDto>>(donors);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetDonors) }");

                return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetDonor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDonor(int id)
        {
            try
            {
                var donor = await _unitOfWork.Donors.Get(d => d.Id == id);
                var result = _mapper.Map<DonorDisplayDto>(donor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetDonor) }");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateDonor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDonor([FromBody] DonorFormDto donorFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateDonor) }");

                return BadRequest(ModelState);
            }

            try
            {
                var donor = _mapper.Map<Donor>(donorFormDto);
                await _unitOfWork.Donors.Insert(donor);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetDonor", new { id = donor.Id }, donor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateDonor) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateDonor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] DonorFormDto donorFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateDonor) }");

                return BadRequest(ModelState);
            }

            try
            {
                var donor = await _unitOfWork.Donors.Get(d => d.Id == id);

                if (donor == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateDonor) }");

                    return BadRequest("Donor not found");
                }

                _mapper.Map(donorFormDto, donor);

                _unitOfWork.Donors.Update(donor);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateDonor) }");

                return StatusCode(500);
            }

        }
        [HttpDelete("{id:int}", Name = "DeleteDonor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteDonor) }");

                return BadRequest();
            }

            try
            {
                var donor = await _unitOfWork.Donors.Get(d => d.Id == id);

                if (donor == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteDonor) }");

                    return BadRequest("Donor not found.");
                }

                await _unitOfWork.Donors.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteDonor) }");

                return StatusCode(500);
            }
        }



    }
}
