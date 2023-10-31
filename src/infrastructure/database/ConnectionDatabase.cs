using Microsoft.EntityFrameworkCore;

using Bed.src.domain.entities;

namespace Bed.src.infrastructure.database;

public class ConnectionDatabase : DbContext
{
    public ConnectionDatabase(DbContextOptions<ConnectionDatabase> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoffeeEntity>().HasIndex(data => data.Name).IsUnique();
    }

    public DbSet<CoffeeEntity> Coffee => Set<CoffeeEntity>();
}