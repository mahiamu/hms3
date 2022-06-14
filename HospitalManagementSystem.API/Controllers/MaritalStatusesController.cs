using AutoMapper;
using HospitalManagementSystem.API.Dtos.MaritalStatuses;
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
    public class MaritalStatusesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MaritalStatusesController> _logger;
        private readonly IMapper _mapper;

        public MaritalStatusesController(
            IUnitOfWork unitOfWork,
            ILogger<MaritalStatusesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMaritalStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMaritalStatuses()
        {
            try
            {
                var maritalStatuses = await _unitOfWork.MaritalStatuses.GetAll();
                var result = _mapper.Map<IList<MaritalStatusDisplayDto>>(maritalStatuses);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetMaritalStatuses) }");

                return StatusCode(500);
            }
        }

    }
}
