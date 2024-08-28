
namespace karyawanApp.Repositories
{
    public class DbPersistance : IPersistance
    {
        private readonly AppDbContext _context;

        public DbPersistance(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}