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
    public class PharmacyMedStocksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PharmacyMedStocksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PharmacyMedStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacyMedStock>>> GetPharmacyMedStocks()
        {
            return await _context.PharmacyMedStocks.ToListAsync();
        }

        // GET: api/PharmacyMedStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacyMedStock>> GetPharmacyMedStock(int id)
        {
            var pharmacyMedStock = await _context.PharmacyMedStocks.FindAsync(id);

            if (pharmacyMedStock == null)
            {
                return NotFound();
            }

            return pharmacyMedStock;
        }

        // PUT: api/PharmacyMedStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacyMedStock(int id, PharmacyMedStock pharmacyMedStock)
        {
            if (id != pharmacyMedStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacyMedStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyMedStockExists(id))
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

        // POST: api/PharmacyMedStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PharmacyMedStock>> PostPharmacyMedStock(PharmacyMedStock pharmacyMedStock)
        {
            _context.PharmacyMedStocks.Add(pharmacyMedStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacyMedStock", new { id = pharmacyMedStock.Id }, pharmacyMedStock);
        }

        // DELETE: api/PharmacyMedStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacyMedStock(int id)
        {
            var pharmacyMedStock = await _context.PharmacyMedStocks.FindAsync(id);
            if (pharmacyMedStock == null)
            {
                return NotFound();
            }

            _context.PharmacyMedStocks.Remove(pharmacyMedStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmacyMedStockExists(int id)
        {
            return _context.PharmacyMedStocks.Any(e => e.Id == id);
        }
    }
}
