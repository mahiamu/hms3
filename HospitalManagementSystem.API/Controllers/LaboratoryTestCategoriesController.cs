using AutoMapper;
using HospitalManagementSystem.API.Dtos.LaboratoryTestCategories;
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
    public class LaboratoryTestCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LaboratoryTestCategoriesController> _logger;
        private readonly IMapper _mapper;

        public LaboratoryTestCategoriesController(
            IUnitOfWork unitOfWork,
            ILogger<LaboratoryTestCategoriesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetLaboratoryTestCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLaboratoryTestCategories()
        {
            try
            {
                var laboratoryTestCategories = await _unitOfWork.LaboratoryTestCategories.GetAll();
                var result = _mapper.Map<IList<LaboratoryTestCategoryDisplayDto>>(laboratoryTestCategories);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetLaboratoryTestCategories) }");

                return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetLaboratoryTestCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLaboratoryTestCategory(int id)
        {
            try
            {
                var laboratoryTestCategory = await _unitOfWork.LaboratoryTestCategories.Get(ltc => ltc.Id == id);
                var result = _mapper.Map<LaboratoryTestCategoryDisplayDto>(laboratoryTestCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetLaboratoryTestCategory) }");

                return StatusCode(500);
            }
        }
        [HttpPost(Name = "CreateLaboratoryTestCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLaboratoryTestCategory([FromBody] LaboratoryTestCategoryFormDto laboratoryTestCategoryFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateLaboratoryTestCategory) }");

                return BadRequest(ModelState);
            }

            try
            {
                var laboratoryTestCategory = _mapper.Map<LaboratoryTestCategory>(laboratoryTestCategoryFormDto);
                await _unitOfWork.LaboratoryTestCategories.Insert(laboratoryTestCategory);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetLaboratoryTestCategory", new { id = laboratoryTestCategory.Id }, laboratoryTestCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateLaboratoryTestCategory) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateLaboratoryTestCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLaboratoryTestCategory(int id, [FromBody] LaboratoryTestCategoryFormDto laboratoryTestCategoryFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateLaboratoryTestCategory) }");

                return BadRequest(ModelState);
            }

            try
            {
                var laboratoryTestCategory = await _unitOfWork.LaboratoryTestCategories.Get(ltc => ltc.Id == id);

                if (laboratoryTestCategory == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateLaboratoryTestCategory) }");

                    return BadRequest("Laboratory Test Category not found");
                }
                _mapper.Map(laboratoryTestCategoryFormDto, laboratoryTestCategory);

                _unitOfWork.LaboratoryTestCategories.Update(laboratoryTestCategory);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateLaboratoryTestCategory) }");

                return StatusCode(500);
            }
        }
        [HttpDelete("{id:int}", Name ="DeleteLaboratoryTestCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLaboratoryTestCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteLaboratoryTestCategory) }");

                return BadRequest();
            }

            try
            {
                var laboratoryTestCategory = await _unitOfWork.LaboratoryTestCategories.Get(ltc => ltc.Id == id);

                if(laboratoryTestCategory == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteLaboratoryTestCategory) }");

                    return BadRequest("Laboratory Test Category not found.");
                }
                await _unitOfWork.LaboratoryTestCategories.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteLaboratoryTestCategory) }");

                return StatusCode(500);
            }
        }
    }
}
