using API1.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace API1.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Marca> Marca { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}
