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
    public class PatientsController : ControllerBase
    {
        private readonly DataContext Context;

        public PatientsController(DataContext context)
        {
            this.Context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatienten()
        {
            return await this.Context.Patienten.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            Patient patient = await this.Context.Patienten.FindAsync(id);

            if (patient == null)
            {
                return this.NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return this.BadRequest();
            }

            this.Context.Entry(patient).State = EntityState.Modified;

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.PatientExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            this.Context.Patienten.Add(patient);
            await this.Context.SaveChangesAsync();

            return this.CreatedAtAction("GetPatient", new {id = patient.Id}, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            Patient patient = await this.Context.Patienten.FindAsync(id);

            if (patient == null)
            {
                return this.NotFound();
            }

            this.Context.Patienten.Remove(patient);
            await this.Context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool PatientExists(int id)
        {
            return this.Context.Patienten.Any(e => e.Id == id);
        }
    }
}