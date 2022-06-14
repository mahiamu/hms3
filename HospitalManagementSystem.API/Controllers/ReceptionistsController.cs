using AutoMapper;
using HospitalManagementSystem.API.Dtos.Receptionists;
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
    public class ReceptionistsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReceptionistsController> _logger;
        private readonly IMapper _mapper;

        public ReceptionistsController(
            IUnitOfWork unitOfWork,
            ILogger<ReceptionistsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetReceptionists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReceptionists()
        {
            try
            {
                var receptionists = await _unitOfWork.Receptionists.GetAll();
                var result = _mapper.Map<IList<ReceptionistDisplayDto>>(receptionists);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetReceptionists) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetReceptionist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReceptionist(int id)
        {
            try
            {
                var receptionist = await _unitOfWork.Receptionists.Get(r => r.Id == id);
                var result = _mapper.Map<ReceptionistDisplayDto>(receptionist);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetReceptionist) }");

                return StatusCode(500);
            }
        }
        [HttpPost(Name = "CreateReceptionist")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateReceptionist([FromBody] ReceptionistFormDto receptionistFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateReceptionist) }");

                return BadRequest(ModelState);
            }

            try
            {
                var receptionist = _mapper.Map<Receptionist>(receptionistFormDto);
                await _unitOfWork.Receptionists.Insert(receptionist);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetReceptionist", new { id = receptionist.Id }, receptionist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateReceptionist) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateReceptionist")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReceptionist(int id, [FromBody] ReceptionistFormDto receptionistFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateReceptionist) }");

                return BadRequest(ModelState);
            }

            try
            {
                var receptionist = await _unitOfWork.Receptionists.Get(r => r.Id == id);

                if (receptionist == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateReceptionist) }");

                    return BadRequest("Receptionist not found");
                }

                _mapper.Map(receptionistFormDto, receptionist);

                _unitOfWork.Receptionists.Update(receptionist);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateReceptionist) }");

                return StatusCode(500);
            }

        }
        [HttpDelete("{id:int}", Name = "DeleteReceptionist")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReceptionist(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteReceptionist) }");

                return BadRequest();
            }

            try
            {
                var receptionist = await _unitOfWork.Receptionists.Get(r => r.Id == id);

                if (receptionist == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteReceptionist) }");

                    return BadRequest("Receptionist not found.");
                }

                await _unitOfWork.Receptionists.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteReceptionist) }");

                return StatusCode(500);
            }
        }
    }
}
