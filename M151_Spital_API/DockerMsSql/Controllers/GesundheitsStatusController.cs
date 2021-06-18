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
    public class GesundheitsStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public GesundheitsStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GesundheitsStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GesundheitsStatus>>> GetGesundheitsStaten()
        {
            return await _context.GesundheitsStaten.ToListAsync();
        }

        // GET: api/GesundheitsStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GesundheitsStatus>> GetGesundheitsStatus(int id)
        {
            var gesundheitsStatus = await _context.GesundheitsStaten.FindAsync(id);

            if (gesundheitsStatus == null)
            {
                return NotFound();
            }

            return gesundheitsStatus;
        }

        // PUT: api/GesundheitsStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGesundheitsStatus(int id, GesundheitsStatus gesundheitsStatus)
        {
            if (id != gesundheitsStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(gesundheitsStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GesundheitsStatusExists(id))
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

        // POST: api/GesundheitsStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GesundheitsStatus>> PostGesundheitsStatus(GesundheitsStatus gesundheitsStatus)
        {
            _context.GesundheitsStaten.Add(gesundheitsStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGesundheitsStatus", new { id = gesundheitsStatus.Id }, gesundheitsStatus);
        }

        // DELETE: api/GesundheitsStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGesundheitsStatus(int id)
        {
            var gesundheitsStatus = await _context.GesundheitsStaten.FindAsync(id);
            if (gesundheitsStatus == null)
            {
                return NotFound();
            }

            _context.GesundheitsStaten.Remove(gesundheitsStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GesundheitsStatusExists(int id)
        {
            return _context.GesundheitsStaten.Any(e => e.Id == id);
        }
    }
}
