using AutoMapper;
using HospitalManagementSystem.API.Dtos.BloodGroups;
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
    public class BloodGroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BloodGroupsController> _logger;
        private readonly IMapper _mapper;

        public BloodGroupsController(
            IUnitOfWork unitOfWork,
            ILogger<BloodGroupsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBloodGroups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBloodGroups()
        {
            try
            {
                var bloodgroups = await _unitOfWork.BloodGroups.GetAll();
                var result = _mapper.Map<IList<BloodGroupDisplayDto>>(bloodgroups);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetBloodGroups) }");

                return StatusCode(500);
            }
        }
    }
}