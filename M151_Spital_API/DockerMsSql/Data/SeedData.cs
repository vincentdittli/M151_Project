namespace M151_Spital.Data
{
    using Microsoft.EntityFrameworkCore;

    public static class SeedData
    {
        private static DataContext _context;

        public static void EnsureDbCreatedAndSeeded(this DataContext context)
        {
            _context = context;
            context.Database.Migrate();

            context.SaveChanges();
        }
    }
}