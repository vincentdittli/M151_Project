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
    public class AdminstratorsController : ControllerBase
    {
        private readonly DataContext Context;

        public AdminstratorsController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/Adminstrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adminstrator>>> GetAdminstratoren()
        {
            return await this.Context.Adminstratoren.ToListAsync();
        }

        // GET: api/Adminstrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adminstrator>> GetAdminstrator(int id)
        {
            Adminstrator adminstrator = await this.Context.Adminstratoren.FindAsync(id);

            if (adminstrator == null)
            {
                return this.NotFound();
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
                return this.BadRequest();
            }

            this.Context.Entry(adminstrator).State = EntityState.Modified;

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.AdminstratorExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/Adminstrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adminstrator>> PostAdminstrator(Adminstrator adminstrator)
        {
            this.Context.Adminstratoren.Add(adminstrator);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetAdminstrator", new {id = adminstrator.Id}, adminstrator);
        }

        // DELETE: api/Adminstrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminstrator(int id)
        {
            Adminstrator adminstrator = await this.Context.Adminstratoren.FindAsync(id);

            if (adminstrator == null)
            {
                return this.NotFound();
            }

            this.Context.Adminstratoren.Remove(adminstrator);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool AdminstratorExists(int id)
        {
            return this.Context.Adminstratoren.Any(e => e.Id == id);
        }
    }
}