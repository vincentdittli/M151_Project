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
    public class AnfragesController : ControllerBase
    {
        private readonly DataContext Context;

        public AnfragesController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/Anfrages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anfrage>>> GetAnfragen()
        {
            return await this.Context.Anfragen.ToListAsync();
        }

        // GET: api/Anfrages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anfrage>> GetAnfrage(int id)
        {
            Anfrage anfrage = await this.Context.Anfragen.FindAsync(id);

            if (anfrage == null)
            {
                return this.NotFound();
            }

            return anfrage;
        }

        // POST: api/Anfrages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anfrage>> PostAnfrage(Anfrage anfrage)
        {
            this.Context.Anfragen.Add(anfrage);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetAnfrage", new {id = anfrage.Id}, anfrage);
        }

        // DELETE: api/Anfrages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnfrage(int id)
        {
            Anfrage anfrage = await this.Context.Anfragen.FindAsync(id);

            if (anfrage == null)
            {
                return this.NotFound();
            }

            this.Context.Anfragen.Remove(anfrage);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool AnfrageExists(int id)
        {
            return this.Context.Anfragen.Any(e => e.Id == id);
        }
    }
}