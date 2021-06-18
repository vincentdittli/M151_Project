namespace M151_Spital.Data
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public static class SeedData
    {
        private static DataContext _context;
        public static void EnsureDbCreatedAndSeeded(this DataContext context)
        {
            _context = context;
            context.Database.Migrate();

            SeedTodos();

            context.SaveChanges();
        }

        private static void SeedTodos()
        {
            if (!_context.Todos.Any())
            {
                var todos = new Todo[]
                {
                    new Todo
                    {
                        Title = "Einkauf Elektronik"
                    },
                    new Todo
                    {
                        Title = "Einkauf Lebensmittel"
                    }
                };

                _context.Todos.AddRange(todos);
            }
        }
    }
}
