using AutoMapper;
using HospitalManagementSystem.API.Dtos.Occupations;
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
    public class OccupationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OccupationsController> _logger;
        private readonly IMapper _mapper;

        public OccupationsController(
            IUnitOfWork unitOfWork,
            ILogger<OccupationsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetOccupation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOccupations()
        {
            try
            {
                var occupations = await _unitOfWork.Occupations.GetAll();
                var result = _mapper.Map<IList<OccupationDisplayDto>>(occupations);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetOccupations) }");

                return StatusCode(500);
            }
        }

    }
}
