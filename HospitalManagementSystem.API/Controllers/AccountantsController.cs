using AutoMapper;
using HospitalManagementSystem.API.Dtos.Accountants;
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
    public class AccountantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountantsController> _logger;
        private readonly IMapper _mapper;

        public AccountantsController(
            IUnitOfWork unitOfWork,
            ILogger<AccountantsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAccountants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountants()
        {
            try
            {
                var accountants = await _unitOfWork.Accountants.GetAll();
                var result = _mapper.Map<IList<AccountantDisplayDto>>(accountants);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetAccountants) }");

                return StatusCode(500);
            }
        }


        [HttpGet("{id:int}", Name = "GetAccountant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountant(int id)
        {
            try
            {
                var accountant = await _unitOfWork.Accountants.Get(at => at.Id == id);
                var result = _mapper.Map<AccountantDisplayDto>(accountant);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetAccountant) }");

                return StatusCode(500);
            }
        }


        [HttpPost(Name = "CreateAccountant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAccountant([FromBody] AccountantFormDto accountantFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateAccountant) }");

                return BadRequest(ModelState);
            }

            try
            {
                var accountant = _mapper.Map<Accountant>(accountantFormDto);
                await _unitOfWork.Accountants.Insert(accountant);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAccountant", new { id = accountant.Id }, accountant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateAccountant) }");

                return StatusCode(500);
            }
        }
        [HttpPut("{id:int}", Name = "UpdateAccountant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccountant(int id, [FromBody] AccountantFormDto accountantFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateAccountant) }");

                return BadRequest(ModelState);
            }

            try
            {
                var accountant = await _unitOfWork.Accountants.Get(at => at.Id == id);

                if (accountant == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateAccountant) }");

                    return BadRequest("Accountant not found");
                }

                _mapper.Map(accountantFormDto, accountant);

                _unitOfWork.Accountants.Update(accountant);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateAccountant) }");

                return StatusCode(500);
            }

        }
        [HttpDelete("{id:int}", Name = "DeleteAccountant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccountant(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteAccountant) }");

                return BadRequest();
            }

            try
            {
                var accountant = await _unitOfWork.Accountants.Get(at => at.Id == id);

                if (accountant == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteAccountant) }");

                    return BadRequest("Accountant not found.");
                }

                await _unitOfWork.Accountants.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteAccountant) }");

                return StatusCode(500);
            }
        }
    }
}

