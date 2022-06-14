using AutoMapper;
using HospitalManagementSystem.API.Dtos.Pathologies;
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
    public class PathologiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PathologiesController> _logger;
        private readonly IMapper _mapper;

        public PathologiesController(
            IUnitOfWork unitOfWork,
            ILogger<PathologiesController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPathologies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPathologies()
        {
            try
            {
                var pathologies = await _unitOfWork.Pathologies.GetAll();
                var result = _mapper.Map<IList<PathologyDisplayDto>>(pathologies);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPathologies) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetPathology")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPathology(int id)
        {
            try
            {
                var pathology = await _unitOfWork.Pathologies.Get(p => p.Id == id);
                var result = _mapper.Map<PathologyDisplayDto>(pathology);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetPathology)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreatePathology")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePathology([FromBody] PathologyFormDto pathologyFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreatePathology) }");

                return BadRequest(ModelState);
            }
            try
            {
                var pathology = _mapper.Map<Pathology>(pathologyFormDto);
                await _unitOfWork.Pathologies.Insert(pathology);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetPathology", new { id = pathology.Id }, pathology);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreatePathology) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdatePathology")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePathology(int id, [FromBody] PathologyFormDto pathologyFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdatePathology) }");

                return BadRequest(ModelState);
            }
            try
            {
                var pathology = await _unitOfWork.Pathologies.Get(p => p.Id == id);

                if (pathology == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdatePathology) }");

                    return BadRequest("Pathology not found");
                }

                _mapper.Map(pathologyFormDto, pathology);

                _unitOfWork.Pathologies.Update(pathology);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdatePathology) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePathology")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePathology(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeletePathology) }");

                return BadRequest();
            }

            try
            {
                var pathology = await _unitOfWork.Pathologies.Get(p => p.Id == id);

                if (pathology == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeletePathology) }");

                    return BadRequest("Pathology not found");
                }

                await _unitOfWork.Pathologies.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeletePathology) }");

                return StatusCode(500);
            }
        }
    }
}
