using Microsoft.EntityFrameworkCore;

public sealed class CoffeeEntityRepository : IRepository
{
    private readonly Database _database;

    public CoffeeEntityRepository(Database database)
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