using Microsoft.EntityFrameworkCore;

using Bed.Src.Domain.Entities;
using Bed.Src.Domain.Repositories;
using Bed.Src.Infrastructure.Database;

namespace Bed.Src.Infrastructure.Repositories
{
    public sealed class CoffeeEntityRepository : IRepository
    {
        private readonly ConnectionDatabase _database;

        public CoffeeEntityRepository(ConnectionDatabase database)
        {
            _database = database;
        }

        public async Task<List<CoffeeEntity>> GetAll() =>
            await _database.Coffee.AsNoTracking().ToListAsync();

        public async Task<CoffeeEntity?> GetById(Guid id) =>
            await _database.Coffee.FirstOrDefaultAsync(entity => entity.Id == id);

        public async Task<CoffeeEntity> Create(CoffeeEntity data)
        {
            _database.Coffee.Add(data);
            await _database.SaveChangesAsync();

            return data;
        }

        public async Task<CoffeeEntity> Update(CoffeeEntity data)
        {
            _database.Update(data);
            await _database.SaveChangesAsync();

            return data;
        }

        public async Task Delete(CoffeeEntity data)
        {
            _database.Remove(data);
            await _database.SaveChangesAsync();
        }
    }
}