using AutoMapper;
using HospitalManagementSystem.API.Dtos.EmployeeRoles;
using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeRolesController> _logger;
        private readonly IMapper _mapper;

        public EmployeeRolesController(
            IUnitOfWork unitOfWork,
            ILogger<EmployeeRolesController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEmployeeRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployeeRoles()
        {
            try
            {
                var employeeRoles = await _unitOfWork.EmployeeRoles.GetAll();
                var result = _mapper.Map<IList<EmployeeRoleDisplayDto>>(employeeRoles);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetEmployeeRoles) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetEmployeeRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployeeRole(int id)
        {
            try
            {
                var employeeRole = await _unitOfWork.EmployeeRoles.Get(at => at.Id == id);
                var result = _mapper.Map<EmployeeRoleDisplayDto>(employeeRole);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetEmployeeRole)}");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateEmployeeRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmployeeRole([FromBody] EmployeeRoleFormDto employeeRoleFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post attempt made at { nameof(CreateEmployeeRole) }");

                return BadRequest(ModelState);
            }
            try
            {
                var employeeRole = _mapper.Map<EmployeeRole>(employeeRoleFormDto);
                await _unitOfWork.EmployeeRoles.Insert(employeeRole);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetEmployeeRole", new { id = employeeRole.Id }, employeeRole);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(CreateEmployeeRole) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateEmployeeRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployeeRole(int id, [FromBody] EmployeeRoleFormDto employeeRoleFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt at { nameof(UpdateEmployeeRole) }");

                return BadRequest(ModelState);
            }
            try
            {
                var employeeRole = await _unitOfWork.EmployeeRoles.Get(at => at.Id == id);

                if (employeeRole == null)
                {
                    _logger.LogError($"Invalid Update attempt at { nameof(UpdateEmployeeRole) }");

                    return BadRequest("Employee role not found");
                }

                _mapper.Map(employeeRoleFormDto, employeeRole);

                _unitOfWork.EmployeeRoles.Update(employeeRole);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(UpdateEmployeeRole) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployeeRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployeeRole(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteEmployeeRole) }");

                return BadRequest();
            }

            try
            {
                var employeeRole = await _unitOfWork.EmployeeRoles.Get(at => at.Id == id);

                if (employeeRole == null)
                {
                    _logger.LogError($"Invalid Delete attempt at { nameof(DeleteEmployeeRole) }");

                    return BadRequest("Employee role not found");
                }

                await _unitOfWork.EmployeeRoles.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong at { nameof(DeleteEmployeeRole) }");

                return StatusCode(500);
            }
        }
    }
}
