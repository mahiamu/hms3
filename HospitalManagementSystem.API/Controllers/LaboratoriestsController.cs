using AutoMapper;
using HospitalManagementSystem.API.Dtos.Laboratorists;
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
    public class LaboratoriestsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LaboratoriestsController> _logger;
        private readonly IMapper _mapper;

        public LaboratoriestsController(
            IUnitOfWork unitOfWork,
            ILogger<LaboratoriestsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetLaboratoriests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLaboratoriests()
        {
            try
            {
                var laboratoriests = await _unitOfWork.Laboratoriests.GetAll();
                var result = _mapper.Map<IList<LaboratoristDisplayDto>>(laboratoriests);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetLaboratoriests) }");

                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetLaboratoriest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLaboratoriest(int id)
        {
            try
            {
                var laboratoriest = await _unitOfWork.Laboratoriests.Get(l => l.Id == id);
                var result = _mapper.Map<LaboratoristDisplayDto>(laboratoriest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetLaboratoriest) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateLaboratoriest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLaboratoriest([FromBody] LaboratoriestFormDto laboratoriestFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateLaboratoriest) }");

                return BadRequest(ModelState);
            }

            try
            {
                var laboratoriest = _mapper.Map<Laboratoriest>(laboratoriestFormDto);
                await _unitOfWork.Laboratoriests.Insert(laboratoriest);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetLaboratoriest", new { id = laboratoriest.Id }, laboratoriest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateLaboratoriest) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateLaboratoriest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLaboratoriest(int id, [FromBody] LaboratoriestFormDto laboratoriestFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateLaboratoriest) }");

                return BadRequest(ModelState);
            }

            try
            {
                var laboratoriest = await _unitOfWork.Laboratoriests.Get(l => l.Id == id);

                if (laboratoriest == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateLaboratoriest) }");

                    return BadRequest("Laboratoriest  not found");
                }

                _mapper.Map(laboratoriestFormDto, laboratoriest);

                _unitOfWork.Laboratoriests.Update(laboratoriest);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateLaboratoriest) }");

                return StatusCode(500);
            }

        }


        [HttpDelete("{id:int}", Name = "DeleteLaboratoriest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLaboratoriest(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteLaboratoriest) }");

                return BadRequest();
            }

            try
            {
                var laboratoriest = await _unitOfWork.Laboratoriests.Get(l => l.Id == id);

                if (laboratoriest == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteLaboratoriest) }");

                    return BadRequest("Laboratoriest not found.");
                }

                await _unitOfWork.Laboratoriests.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteLaboratoriest) }");

                return StatusCode(500);
            }
        }
    }
}
