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
    public class AnfragesController : ControllerBase
    {
        private readonly DataContext _context;

        public AnfragesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Anfrages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anfrage>>> GetAnfragen()
        {
            return await _context.Anfragen.ToListAsync();
        }

        // GET: api/Anfrages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anfrage>> GetAnfrage(int id)
        {
            var anfrage = await _context.Anfragen.FindAsync(id);

            if (anfrage == null)
            {
                return NotFound();
            }

            return anfrage;
        }

        // PUT: api/Anfrages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnfrage(int id, Anfrage anfrage)
        {
            if (id != anfrage.Id)
            {
                return BadRequest();
            }

            _context.Entry(anfrage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnfrageExists(id))
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

        // POST: api/Anfrages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anfrage>> PostAnfrage(Anfrage anfrage)
        {
            _context.Anfragen.Add(anfrage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnfrage", new { id = anfrage.Id }, anfrage);
        }

        // DELETE: api/Anfrages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnfrage(int id)
        {
            var anfrage = await _context.Anfragen.FindAsync(id);
            if (anfrage == null)
            {
                return NotFound();
            }

            _context.Anfragen.Remove(anfrage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnfrageExists(int id)
        {
            return _context.Anfragen.Any(e => e.Id == id);
        }
    }
}
