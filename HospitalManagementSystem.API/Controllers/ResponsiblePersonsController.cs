using AutoMapper;
using HospitalManagementSystem.API.Dtos.ResponsiblePersons;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsiblePersonsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ResponsiblePersonsController> _logger;
        private readonly IMapper _mapper;

        public ResponsiblePersonsController(IMapper mapper, ILogger<ResponsiblePersonsController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetResponsiblePersons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResponsiblePersons()
        {
            try
            {
                var responsiblePersons = await _unitOfWork.ResponsiblePersons.GetAll();
                var result = _mapper.Map<IList<ResponsiblePersonDisplayDto>>(responsiblePersons);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetResponsiblePersons)}");
                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateResponsiblePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateResponsiblePerson([FromBody] ResponsiblePersonFormDto responsiblePersonFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in {nameof(CreateResponsiblePerson)}");

                return BadRequest(ModelState);
            }

            try
            {
                var responsiblePerson = _mapper.Map<ResponsiblePerson>(responsiblePersonFormDto);
                await _unitOfWork.ResponsiblePersons.Insert(responsiblePerson);
                await _unitOfWork.Save();

                return CreatedAtRoute("CreateResponsiblePerson", new { id = responsiblePerson.Id }, responsiblePerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at {nameof(CreateResponsiblePerson)}");
                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateResponsiblePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateResponsiblePerson(int id, [FromBody] ResponsiblePersonFormDto responsiblePersonFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateResponsiblePerson) }");

                return BadRequest(ModelState);
            }

            try
            {
                var responsiblePerson = await _unitOfWork.ResponsiblePersons.Get(p => p.Id == id);

                if (responsiblePerson == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateResponsiblePerson) }");

                    return BadRequest("Responsible person not found");
                }

                _mapper.Map(responsiblePersonFormDto, responsiblePerson);
                _unitOfWork.ResponsiblePersons.Update(responsiblePerson);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateResponsiblePerson) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteResponsiblePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteResponsiblePerson(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteResponsiblePerson) }");

                return BadRequest();
            }

            try
            {
                var responsiblePerson = await _unitOfWork.ResponsiblePersons.Get(rp => rp.Id == id);

                if (responsiblePerson == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteResponsiblePerson) }");

                    return BadRequest("Responsible person not found");
                }

                await _unitOfWork.ResponsiblePersons.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteResponsiblePerson) }");

                return StatusCode(500);
            }
        }
    }
}
