using DomainService.Dal.Seed;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Dal;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}
