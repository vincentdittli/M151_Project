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
    public class DoktorsController : ControllerBase
    {
        private readonly DataContext Context;

        public DoktorsController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/Doktors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doktor>>> GetDoktoren()
        {
            return await this.Context.Doktoren.ToListAsync();
        }

        // GET: api/Doktors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doktor>> GetDoktor(int id)
        {
            Doktor doktor = await this.Context.Doktoren.FindAsync(id);

            if (doktor == null)
            {
                return this.NotFound();
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
                return this.BadRequest();
            }

            this.Context.Entry(doktor).State = EntityState.Modified;

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.DoktorExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/Doktors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doktor>> PostDoktor(Doktor doktor)
        {
            this.Context.Doktoren.Add(doktor);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetDoktor", new {id = doktor.Id}, doktor);
        }

        // DELETE: api/Doktors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoktor(int id)
        {
            Doktor doktor = await this.Context.Doktoren.FindAsync(id);

            if (doktor == null)
            {
                return this.NotFound();
            }

            this.Context.Doktoren.Remove(doktor);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool DoktorExists(int id)
        {
            return this.Context.Doktoren.Any(e => e.Id == id);
        }
    }
}