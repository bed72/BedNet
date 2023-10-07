using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<CoffeeEntity> Coffee => Set<CoffeeEntity>();
}