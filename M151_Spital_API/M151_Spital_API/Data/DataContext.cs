namespace M151_Spital_API.Data
{
    using M151_Spital_API.Models;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Adminstrator> Adminstratoren { get; set; }
        public DbSet<Anfrage> Anfragen { get; set; }
        public DbSet<Doktor> Doktoren { get; set; }
        public DbSet<GesundheitsStatus> GesundheitsStaten { get; set; }
        public DbSet<Patient> Patienten { get; set; }
        public DbSet<Person> Personen { get; set; }
    }
}
