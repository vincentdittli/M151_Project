namespace M151_Spital.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using M151_Spital.Data;
    using M151_Spital.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class GesundheitsStatusController : ControllerBase
    {
        private readonly DataContext Context;

        public GesundheitsStatusController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/GesundheitsStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GesundheitsStatus>>> GetGesundheitsStaten()
        {
            return await this.Context.GesundheitsStaten.ToListAsync();
        }

        // GET: api/GesundheitsStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GesundheitsStatus>> GetGesundheitsStatus(int id)
        {
            GesundheitsStatus gesundheitsStatus = await this.Context.GesundheitsStaten.FindAsync(id);

            if (gesundheitsStatus == null)
            {
                return this.NotFound();
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
                return this.BadRequest();
            }

            this.Context.Entry(gesundheitsStatus).State = EntityState.Modified;

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.GesundheitsStatusExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/GesundheitsStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GesundheitsStatus>> PostGesundheitsStatus(GesundheitsStatus gesundheitsStatus)
        {
            this.Context.GesundheitsStaten.Add(gesundheitsStatus);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetGesundheitsStatus", new {id = gesundheitsStatus.Id}, gesundheitsStatus);
        }

        // DELETE: api/GesundheitsStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGesundheitsStatus(int id)
        {
            GesundheitsStatus gesundheitsStatus = await this.Context.GesundheitsStaten.FindAsync(id);

            if (gesundheitsStatus == null)
            {
                return this.NotFound();
            }

            this.Context.GesundheitsStaten.Remove(gesundheitsStatus);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool GesundheitsStatusExists(int id)
        {
            return this.Context.GesundheitsStaten.Any(e => e.Id == id);
        }
    }
}