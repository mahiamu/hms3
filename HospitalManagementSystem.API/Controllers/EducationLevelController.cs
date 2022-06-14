using AutoMapper;
using HospitalManagementSystem.API.Dtos.EducationLevels;
using HospitalManagementSystem.API.IRepositories;
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
    public class EducationLevelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EducationLevelController> _logger;
        private readonly IMapper _mapper;

        public EducationLevelController(
            IUnitOfWork unitOfWork,
            ILogger<EducationLevelController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "EducationLevels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEducationLevels()
        {
            try
            {
                var educationLevels = await _unitOfWork.EducationLevels.GetAll();
                var result = _mapper.Map<IList<EducationLevelDisplayDto>>(educationLevels);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetEducationLevels) }");

                return StatusCode(500);
            }
        }
    }
}
