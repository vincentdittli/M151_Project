using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M151_Spital.Data;
using M151_Spital.Models;

namespace M151_Spital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoktorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DoktorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Doktors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doktor>>> GetDoktoren()
        {
            return await _context.Doktoren.ToListAsync();
        }

        // GET: api/Doktors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doktor>> GetDoktor(int id)
        {
            var doktor = await _context.Doktoren.FindAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            return doktor;
        }

        // PUT: api/Doktors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoktor(int id, Doktor doktor)
        {
            if (id != doktor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doktor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoktorExists(id))
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

        // POST: api/Doktors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doktor>> PostDoktor(Doktor doktor)
        {
            _context.Doktoren.Add(doktor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoktor", new { id = doktor.Id }, doktor);
        }

        // DELETE: api/Doktors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoktor(int id)
        {
            var doktor = await _context.Doktoren.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            _context.Doktoren.Remove(doktor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktoren.Any(e => e.Id == id);
        }
    }
}
