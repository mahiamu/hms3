using AutoMapper;
using HospitalManagementSystem.API.Dtos.Weekdays;
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
    public class WeekdaysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WeekdaysController> _logger;
        private readonly IMapper _mapper;

        public WeekdaysController(
            IUnitOfWork unitOfWork,
            ILogger<WeekdaysController> logger,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeekdays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWeekdays()
        {
            try
            {
                var weekdays = await _unitOfWork.Weekdays.GetAll();
                var result = _mapper.Map<IList<WeekdayDisplayDto>>(weekdays);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetWeekdays) }");

                return StatusCode(500);
            }
        }
    }
}
