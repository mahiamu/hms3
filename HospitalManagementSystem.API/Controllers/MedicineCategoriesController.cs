using AutoMapper;
using HospitalManagementSystem.API.Dtos.MedicineCategories;
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
    public class MedicineCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MedicineCategoriesController> _logger;
        private readonly IMapper _mapper;
        public MedicineCategoriesController(
          IUnitOfWork unitOfWork,
          ILogger<MedicineCategoriesController> logger,
          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMedicineCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicineCategories()
        {
            try
            {
                var medicineCategories = await _unitOfWork.MedicineCategories.GetAll();
                var result = _mapper.Map<IList<MedicineCategoryDisplayDto>>(medicineCategories);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetMedicineCategories) }");

                return StatusCode(500);
            }
        }
        [HttpGet("{id:int}", Name = "GetMedicineCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicineCategory(int id)
        {
            try
            {
                var medicineCategory= await _unitOfWork.MedicineCategories.Get(at => at.Id == id);
                var result = _mapper.Map<MedicineCategoryDisplayDto>(medicineCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetMedicineCategory) }");

                return StatusCode(500);
            }
        }
        [HttpPost(Name = "CreateMedicineCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMedicineCategory([FromBody] MedicineCategoryFormDto medicineCategoryFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateMedicineCategory) }");

                return BadRequest(ModelState);
            }

            try
            {
                var medicineCategory = _mapper.Map<MedicineCategory>(medicineCategoryFormDto);
                await _unitOfWork.MedicineCategories.Insert(medicineCategory);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetMedicineCategory", new { id = medicineCategory.Id }, medicineCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateMedicineCategory) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateMedicineCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMedicineCategory(int id, [FromBody] MedicineCategoryFormDto medicineCategoryFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateMedicineCategory) }");

                return BadRequest(ModelState);
            }

            try
            {
                var medicineCategory = await _unitOfWork.MedicineCategories.Get(at => at.Id == id);

                if (medicineCategory == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateMedicineCategory) }");

                    return BadRequest("Medicine Category not found");
                }

                _mapper.Map(medicineCategoryFormDto, medicineCategory);

                _unitOfWork.MedicineCategories.Update(medicineCategory);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateMedicineCategory) }");

                return StatusCode(500);
            }

        }
        [HttpDelete("{id:int}", Name = "DeleteMedicineCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMedicineCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteMedicineCategory) }");

                return BadRequest();
            }

            try
            {
                var medicineCategory = await _unitOfWork.MedicineCategories.Get(at => at.Id == id);

                if (medicineCategory == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteMedicineCategory) }");

                    return BadRequest("Medicine Category not found.");
                }

                await _unitOfWork.MedicineCategories.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteMedicineCategory) }");

                return StatusCode(500);
            }
        }



    }
}
