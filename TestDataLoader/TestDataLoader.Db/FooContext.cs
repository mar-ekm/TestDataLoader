using Microsoft.EntityFrameworkCore;

namespace TestDataLoader.Db;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Foo> Foos { get; set; }
}