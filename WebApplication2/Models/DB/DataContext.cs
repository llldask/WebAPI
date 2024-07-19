using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PlaySession> playSessions { get; set; }

    }
}
