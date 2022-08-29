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
    public class BillLabsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BillLabsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BillLabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillLab>>> GetBillLabs()
        {
            return await _context.BillLabs.ToListAsync();
        }

        // GET: api/BillLabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillLab>> GetBillLab(int id)
        {
            var billLab = await _context.BillLabs.FindAsync(id);

            if (billLab == null)
            {
                return NotFound();
            }

            return billLab;
        }

        // PUT: api/BillLabs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillLab(int id, BillLab billLab)
        {
            if (id != billLab.Id)
            {
                return BadRequest();
            }

            _context.Entry(billLab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillLabExists(id))
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

        // POST: api/BillLabs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillLab>> PostBillLab(BillLab billLab)
        {
            _context.BillLabs.Add(billLab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillLab", new { id = billLab.Id }, billLab);
        }

        // DELETE: api/BillLabs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillLab(int id)
        {
            var billLab = await _context.BillLabs.FindAsync(id);
            if (billLab == null)
            {
                return NotFound();
            }

            _context.BillLabs.Remove(billLab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillLabExists(int id)
        {
            return _context.BillLabs.Any(e => e.Id == id);
        }
    }
}
