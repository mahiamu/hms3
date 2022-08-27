using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.API.Data;
using HospitalManagementSystem.API.Models;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillSchedulesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BillSchedulesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BillSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillSchedule>>> GetBillSchedules()
        {
            return await _context.BillSchedules.Include(b => b.PatientSchedule)
                .Include(b => b.Employee)
               
               .ToListAsync();
        }

        // GET: api/BillSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillSchedule>> GetBillSchedule(int id)
        {
            var billSchedule = await _context.BillSchedules.FindAsync(id);

            if (billSchedule == null)
            {
                return NotFound();
            }

            return billSchedule;
        }

        // PUT: api/BillSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillSchedule(int id, BillSchedule billSchedule)
        {
            if (id != billSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(billSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillScheduleExists(id))
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

        // POST: api/BillSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillSchedule>> PostBillSchedule(BillSchedule billSchedule)
        {
            _context.BillSchedules.Add(billSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillSchedule", new { id = billSchedule.Id }, billSchedule);
        }

        // DELETE: api/BillSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillSchedule(int id)
        {
            var billSchedule = await _context.BillSchedules.FindAsync(id);
            if (billSchedule == null)
            {
                return NotFound();
            }

            _context.BillSchedules.Remove(billSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillScheduleExists(int id)
        {
            return _context.BillSchedules.Any(e => e.Id == id);
        }
    }
}
