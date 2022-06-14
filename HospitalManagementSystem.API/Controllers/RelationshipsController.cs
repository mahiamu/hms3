using AutoMapper;
using HospitalManagementSystem.API.Dtos.Relationships;
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
    public class RelationshipsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RelationshipsController> _logger;
        private readonly IMapper _mapper;

        public RelationshipsController(
            IUnitOfWork unitOfWork,
            ILogger<RelationshipsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRelationships")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRelationships()
        {
            try
            {
                var relationships = await _unitOfWork.Relationships.GetAll();
                var result = _mapper.Map<IList<RelationshipDisplayDto>>(relationships);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Someting went wrong in { nameof(GetRelationships) }");

                return StatusCode(500);
            }
        }
    }
}
