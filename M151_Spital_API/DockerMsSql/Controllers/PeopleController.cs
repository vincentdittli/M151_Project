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
    public class PeopleController : ControllerBase
    {
        private readonly DataContext Context;

        public PeopleController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonen()
        {
            return await this.Context.Personen.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            Person person = await this.Context.Personen.FindAsync(id);

            if (person == null)
            {
                return this.NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return this.BadRequest();
            }

            this.Context.Entry(person).State = EntityState.Modified;

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.PersonExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            this.Context.Personen.Add(person);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetPerson", new {id = person.Id}, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            Person person = await this.Context.Personen.FindAsync(id);

            if (person == null)
            {
                return this.NotFound();
            }

            this.Context.Personen.Remove(person);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool PersonExists(int id)
        {
            return this.Context.Personen.Any(e => e.Id == id);
        }
    }
}