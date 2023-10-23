using Microsoft.EntityFrameworkCore;

using Bed.src.domain.entities;
using Bed.src.domain.repositories;
using Bed.src.infrastructure.database;

namespace Bed.src.infrastructure.repositories;

public sealed class CoffeeEntityRepository : IRepository
{
    private readonly ConnectionDatabase _database;

    public CoffeeEntityRepository(ConnectionDatabase database)
    {
        _database = database;
    }

    public async Task<List<CoffeeEntity>> GetAll(Tuple<int, int> data) =>
        await _database.Coffee
            .AsNoTracking()
            .Skip((data.Item1 - 1) * data.Item2)
            .Take(data.Item2)
            .ToListAsync();

    public async Task<CoffeeEntity?> GetById(Guid id) =>
        await _database.Coffee.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);

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
