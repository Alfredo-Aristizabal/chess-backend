using ChessBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessBackend
{
    public class ChessBackendDbContext : DbContext
    {

        public ChessBackendDbContext()
        {

        }

        public ChessBackendDbContext(DbContextOptions<ChessBackendDbContext> options) : base (options)
        {

        }

        public DbSet<User> Users => Set<User>();
    }
}
