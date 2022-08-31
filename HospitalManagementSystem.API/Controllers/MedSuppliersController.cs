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
    public class MedSuppliersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MedSuppliersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MedSuppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedSupplier>>> GetMedSuppliers()
        {
            return await _context.MedSuppliers.ToListAsync();
        }

        // GET: api/MedSuppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedSupplier>> GetMedSupplier(int id)
        {
            var medSupplier = await _context.MedSuppliers.FindAsync(id);

            if (medSupplier == null)
            {
                return NotFound();
            }

            return medSupplier;
        }

        // PUT: api/MedSuppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedSupplier(int id, MedSupplier medSupplier)
        {
            if (id != medSupplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(medSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedSupplierExists(id))
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

        // POST: api/MedSuppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedSupplier>> PostMedSupplier(MedSupplier medSupplier)
        {
            _context.MedSuppliers.Add(medSupplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedSupplier", new { id = medSupplier.Id }, medSupplier);
        }

        // DELETE: api/MedSuppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedSupplier(int id)
        {
            var medSupplier = await _context.MedSuppliers.FindAsync(id);
            if (medSupplier == null)
            {
                return NotFound();
            }

            _context.MedSuppliers.Remove(medSupplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedSupplierExists(int id)
        {
            return _context.MedSuppliers.Any(e => e.Id == id);
        }
    }
}
