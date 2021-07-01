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
    public class PacientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("filter/{minAge}")]
        public ActionResult<IEnumerable<Pacient>> FilterPacients(int minAge)
        {
            return  _context.Pacients.Where(a => a.Age >= minAge).ToList();
        }

        // GET: api/Pacient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacient>>> GetPacients(int? minAge)
        {
            if (minAge == null)
            {
                return await _context.Pacients.ToListAsync();
            }
            return await _context.Pacients.Where(a => a.Age >= minAge).ToListAsync();
        }

        // GET: api/Pacient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacient>> GetPacient(int id)
        {
            var pacient = await _context.Pacients.FindAsync(id);

            if (pacient == null)
            {
                return NotFound();
            }

            return pacient;
        }

        // PUT: api/Pacient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacient(int id, Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(id))
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

        // POST: api/Pacient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacient>> PostPacient(Pacient pacient)
        {
            _context.Pacients.Add(pacient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacient", new { id = pacient.Id }, pacient);
        }

        // DELETE: api/Pacient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacient(int id)
        {
            var pacient = await _context.Pacients.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }

            _context.Pacients.Remove(pacient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientExists(int id)
        {
            return _context.Pacients.Any(e => e.Id == id);
        }
    }
}
