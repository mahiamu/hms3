using AutoMapper;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Dtos.WardTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementSystem.API.Models;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WardTypesController> _logger;
        private readonly IMapper _mapper;

        public WardTypesController(
            IUnitOfWork unitOfWork,
            ILogger<WardTypesController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWardTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWardTypes()
        {
            try
            {
                var wardTypes = await _unitOfWork.WardTypes.GetAll();
                var result = _mapper.Map<IList<WardTypeDisplayDto>>(wardTypes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetWardTypes) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetWardType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWardType(int id)
        {
            try
            {
                var wardType = await _unitOfWork.WardTypes.Get(wt => wt.Id == id);
                var result = _mapper.Map<WardTypeDisplayDto>(wardType);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetWardType)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateWardType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateWardType([FromBody] WardTypeFormDto wardTypeFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateWardType) }");

                return BadRequest(ModelState);
            }
            try
            {
                var wardType = _mapper.Map<WardType>(wardTypeFormDto);
                await _unitOfWork.WardTypes.Insert(wardType);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetWardType", new { id = wardType.Id }, wardType);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateWardType) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateWardType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateWardType(int id, [FromBody] WardTypeFormDto wardTypeFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateWardType) }");

                return BadRequest(ModelState);
            }
            try
            {
                var wardType = await _unitOfWork.WardTypes.Get(wt => wt.Id == id);

                if (wardType == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateWardType) }");

                    return BadRequest("Ward type not found");
                }

                _mapper.Map(wardTypeFormDto, wardType);

                _unitOfWork.WardTypes.Update(wardType);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateWardType) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteWardType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteWardType(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteWardType) }");

                return BadRequest();
            }

            try
            {
                var wardType = await _unitOfWork.WardTypes.Get(wt => wt.Id == id);

                if (wardType == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteWardType) }");

                    return BadRequest("Ward type not found");
                }

                await _unitOfWork.WardTypes.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteWardType) }");

                return StatusCode(500);
            }
        }
    }
}
