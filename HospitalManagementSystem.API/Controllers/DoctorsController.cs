using AutoMapper;
using HospitalManagementSystem.API.Dtos.Doctors;
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
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DoctorsController> _logger;
        private readonly IMapper _mapper;

        public DoctorsController(
            IUnitOfWork unitOfWork,
            ILogger<DoctorsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await _unitOfWork.Doctors.GetAll();
                var result = _mapper.Map<IList<DoctorDisplayDto>>(doctors);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetDoctors) }");

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "GetDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDoctor(int id)
        {
            try
            {
                var doctor = await _unitOfWork.Doctors.Get(d => d.Id == id);
                var result = _mapper.Map<DoctorDisplayDto>(doctor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(GetDoctor) }");

                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateDoctor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorFormDto doctorFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST request attempt made in { nameof(CreateDoctor) }");

                return BadRequest(ModelState);
            }
            try
            {
                var doctor = _mapper.Map<Doctor>(doctorFormDto);
                await _unitOfWork.Doctors.Insert(doctor);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetDoctor", new { id = doctor.Id }, doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the { nameof(CreateDoctor) }");

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorFormDto doctorFormDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE request attempt made in { nameof(UpdateDoctor) }");

                return BadRequest(ModelState);
            }

            try
            {
                var doctor = await _unitOfWork.Doctors.Get(d => d.Id == id);

                if (doctor == null)
                {
                    _logger.LogError($"Invalid UPDATE request attempt in { nameof(UpdateDoctor) }");

                    return BadRequest("Doctor not found");
                }

                _mapper.Map(doctorFormDto, doctor);
                _unitOfWork.Doctors.Update(doctor);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(UpdateDoctor) }");

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE request attempt made in { nameof(DeleteDoctor) }");

                return BadRequest();
            }
            try
            {
                var doctor = await _unitOfWork.Doctors.Get(d => d.Id == id);

                if (doctor == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in { nameof(DeleteDoctor) }");

                    return BadRequest("Doctor not found.");
                }

                await _unitOfWork.Doctors.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in { nameof(DeleteDoctor) }");
                
                return StatusCode(500);
            }
        }
    }
}
