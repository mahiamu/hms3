using AutoMapper;
using HospitalManagementSystem.API.Dtos.Cases;
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
    public class CasesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CasesController> _logger;
        private readonly IMapper _mapper;

        public CasesController(
            IUnitOfWork unitOfWork,
            ILogger<CasesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCases()
        {
            try
            {
                var cases = await _unitOfWork.Cases.GetAll();
                var result = _mapper.Map<IList<CaseDisplayDto>>(cases);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetCases) }");

                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCase(int id)
        {
            try
            {
                var cases = await _unitOfWork.Cases.Get(c => c.Id == id);
                var result = _mapper.Map<CaseDisplayDto>(cases);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetCase) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateCase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCase([FromBody] CaseFormDto caseFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateCase) }");

                return BadRequest(ModelState);
            }

            try
            {
                var cases = _mapper.Map<Case>(caseFormDto);
                await _unitOfWork.Cases.Insert(cases);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetCase", new { id = cases.Id }, cases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateCase) }");

                return StatusCode(500);
            }
        }


        [HttpPut("{id:int}", Name = "UpdateCase")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCase(int id, [FromBody] CaseFormDto caseFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateCase) }");

                return BadRequest(ModelState);
            }

            try
            {
                var cases = await _unitOfWork.Cases.Get(c => c.Id == id);

                if (cases == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateCase) }");

                    return BadRequest("Case not found");
                }

                _mapper.Map(caseFormDto, cases);

                _unitOfWork.Cases.Update(cases);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateCase) }");

                return StatusCode(500);
            }

        } 


        [HttpDelete("{id:int}", Name = "DeleteCase")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCase(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteCase) }");

                return BadRequest();
            }

            try
            {
                var cases = await _unitOfWork.Cases.Get(c => c.Id == id);

                if (cases == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteCase) }");

                    return BadRequest("Case not found.");
                }

                await _unitOfWork.Cases.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteCase) }");

                return StatusCode(500);
            }
        }
    }
}
