using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.API.Data;
using HospitalManagementSystem.API.Models;
using AutoMapper;
using HospitalManagementSystem.API.Dtos.PatientSchedules;
using Microsoft.Extensions.Logging;
using HospitalManagementSystem.API.IRepositories;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientSchedulesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
       
        public PatientSchedulesController(IMapper mapper , DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;

        }

      

        // GET: api/PatientSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientSchedule>>> GetPatientSchedules()
        {
            var patientschedules = await _context.PatientSchedules.Include(e => e.Patient)
                .Include(e => e.Employee)
                .Include(e => e.AdmissionType)
                .Include(e => e.Room)

                .ToListAsync();
           
           // var result = _mapper.Map<IList<PatientScheduleDisplayDto>>(patientschedules);
            return Ok(patientschedules);

               
        }

        // GET: api/PatientSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientSchedule>> GetPatientSchedule(int id)
        {
            var patientSchedule = await _context.PatientSchedules.FindAsync(id);

            if (patientSchedule == null)
            {
                return NotFound();
            }

            return patientSchedule;
        }

        // PUT: api/PatientSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientSchedule(int id, PatientSchedule patientSchedule)
        {
            if (id != patientSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientSchedule>> PostPatientSchedule(PatientSchedule patientSchedule)
        {
            _context.PatientSchedules.Add(patientSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientSchedule", new { id = patientSchedule.Id }, patientSchedule);
        }

        // DELETE: api/PatientSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientSchedule(int id)
        {
            var patientSchedule = await _context.PatientSchedules.FindAsync(id);
            if (patientSchedule == null)
            {
                return NotFound();
            }

            _context.PatientSchedules.Remove(patientSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientScheduleExists(int id)
        {
            return _context.PatientSchedules.Any(e => e.Id == id);
        }
    }
}
