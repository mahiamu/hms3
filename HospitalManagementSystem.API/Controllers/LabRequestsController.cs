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
    public class LabRequestsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LabRequestsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LabRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabRequest>>> GetLabrequests()
        {
            return await _context.LabRequests.ToListAsync();
        }

        // GET: api/LabRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabRequest>> GetLabRequest(int id)
        {
            var labRequest = await _context.LabRequests.FindAsync(id);

            if (labRequest == null)
            {
                return NotFound();
            }

            return labRequest;
        }

        // PUT: api/LabRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabRequest(int id, LabRequest labRequest)
        {
            if (id != labRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(labRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabRequestExists(id))
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

        // POST: api/LabRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LabRequest>> PostLabRequest(LabRequest labRequest)
        {
            _context.LabRequests.Add(labRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabRequest", new { id = labRequest.Id }, labRequest);
        }

        // DELETE: api/LabRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabRequest(int id)
        {
            var labRequest = await _context.LabRequests.FindAsync(id);
            if (labRequest == null)
            {
                return NotFound();
            }

            _context.LabRequests.Remove(labRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LabRequestExists(int id)
        {
            return _context.LabRequests.Any(e => e.Id == id);
        }
    }
}
