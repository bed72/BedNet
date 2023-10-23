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

    public DbSet<CoffeeEntity> Coffee => Set<CoffeeEntity>();
}
