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
    public class AdminstratorsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminstratorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Adminstrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adminstrator>>> GetAdminstratoren()
        {
            return await _context.Adminstratoren.ToListAsync();
        }

        // GET: api/Adminstrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adminstrator>> GetAdminstrator(int id)
        {
            var adminstrator = await _context.Adminstratoren.FindAsync(id);

            if (adminstrator == null)
            {
                return NotFound();
            }

            return adminstrator;
        }

        // PUT: api/Adminstrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminstrator(int id, Adminstrator adminstrator)
        {
            if (id != adminstrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminstrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminstratorExists(id))
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

        // POST: api/Adminstrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adminstrator>> PostAdminstrator(Adminstrator adminstrator)
        {
            _context.Adminstratoren.Add(adminstrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminstrator", new { id = adminstrator.Id }, adminstrator);
        }

        // DELETE: api/Adminstrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminstrator(int id)
        {
            var adminstrator = await _context.Adminstratoren.FindAsync(id);
            if (adminstrator == null)
            {
                return NotFound();
            }

            _context.Adminstratoren.Remove(adminstrator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminstratorExists(int id)
        {
            return _context.Adminstratoren.Any(e => e.Id == id);
        }
    }
}
