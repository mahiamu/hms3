using AutoMapper;
using HospitalManagementSystem.API.Dtos.Recommendations;
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
    public class RecommendationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecommendationsController> _logger;
        private readonly IMapper _mapper;
        public RecommendationsController(
            IUnitOfWork unitOfWork,
            ILogger<RecommendationsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetRecommendations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecommendations()
        {
            try
            {
                var recommendations = await _unitOfWork.Recommendations.GetAll();
                var result = _mapper.Map<IList<RecommendationDisplayDto>>(recommendations);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetRecommendations) }");

                return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetRecommendation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecommendation(int id)
        {
            try
            {
                var recommendation = await _unitOfWork.Recommendations.Get(r => r.Id == id);
                var result = _mapper.Map<RecommendationDisplayDto>(recommendation);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetRecommendation)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateRecommendation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRecommendation([FromBody] RecommendationFormDto recommendationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateRecommendation)}");

                return BadRequest(ModelState);
            }
            try
            {
                var recommendation = _mapper.Map<Recommendation>(recommendationFormDto);
                await _unitOfWork.Recommendations.Insert(recommendation);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetRecommendation", new { id = recommendation.Id }, recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateRecommendation)}");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateRecommendation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRecommendation(int id, [FromBody] RecommendationFormDto recommendationFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateRecommendation)}");

                return BadRequest(ModelState);
            }
            try
            {
                var recommendation = await _unitOfWork.Recommendations.Get(r => r.Id == id);

                if (recommendation == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateRecommendation)}");

                    return BadRequest("Recommendation not found");
                }

                _mapper.Map(recommendationFormDto, recommendation);

                _unitOfWork.Recommendations.Update(recommendation);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateRecommendation)}");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteRecommendation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteRecommendation)}");

                return BadRequest();
            }

            try
            {
                var recommendation = await _unitOfWork.Recommendations.Get(r => r.Id == id);

                if (recommendation == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteRecommendation)}");

                    return BadRequest("Recommendation not found.");
                }

                await _unitOfWork.Recommendations.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteRecommendation)}");

                return StatusCode(500);
            }
        }
    }
}
