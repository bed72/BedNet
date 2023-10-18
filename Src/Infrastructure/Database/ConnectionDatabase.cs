using Bed.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bed.Src.Infrastructure.Database
{
    public class ConnectionDatabase : DbContext
    {
        public ConnectionDatabase(DbContextOptions<ConnectionDatabase> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

        public DbSet<CoffeeEntity> Coffee => Set<CoffeeEntity>();
    }
}