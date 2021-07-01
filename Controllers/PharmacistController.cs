using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;

namespace ProiectFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PharmacistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pharmacist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacist>>> GetPharmacists()
        {
            return await _context.Pharmacists.ToListAsync();
        }

        // GET: api/Pharmacist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacist>> GetPharmacist(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);

            if (pharmacist == null)
            {
                return NotFound();
            }

            return pharmacist;
        }

        // PUT: api/Pharmacist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacist(int id, Pharmacist pharmacist)
        {
            if (id != pharmacist.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacistExists(id))
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

        // POST: api/Pharmacist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pharmacist>> PostPharmacist(Pharmacist pharmacist)
        {
            _context.Pharmacists.Add(pharmacist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacist", new { id = pharmacist.Id }, pharmacist);
        }

        // DELETE: api/Pharmacist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacist(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            _context.Pharmacists.Remove(pharmacist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmacistExists(int id)
        {
            return _context.Pharmacists.Any(e => e.Id == id);
        }
    }
}
