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
    public class WardsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WardsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Wards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ward>>> GetWards()
        {
            return await _context.Wards.ToListAsync();
        }

        // GET: api/Wards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ward>> GetWard(int id)
        {
            var ward = await _context.Wards.FindAsync(id);

            if (ward == null)
            {
                return NotFound();
            }

            return ward;
        }

        // PUT: api/Wards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWard(int id, Ward ward)
        {
            if (id != ward.Id)
            {
                return BadRequest();
            }

            _context.Entry(ward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardExists(id))
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

        // POST: api/Wards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ward>> PostWard(Ward ward)
        {
            _context.Wards.Add(ward);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWard", new { id = ward.Id }, ward);
        }

        // DELETE: api/Wards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWard(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }

            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WardExists(int id)
        {
            return _context.Wards.Any(e => e.Id == id);
        }
    }
}
