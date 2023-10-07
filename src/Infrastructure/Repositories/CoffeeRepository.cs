using Microsoft.EntityFrameworkCore;

public sealed class CoffeeRepository : ICoffeeRepository
{
    private readonly Database _database;

    public CoffeeRepository(Database database)
    {
        _database = database;
    }

    public async Task<List<Coffee>> GetCoffees() =>
        await _database.Coffees.AsNoTracking().ToListAsync();

    public async Task<Coffee?> GetCoffee(Guid id) =>
        await _database.Coffees.FirstOrDefaultAsync(coffee => coffee.Id == id);

    public async Task<Coffee> CreateCoffee(Coffee coffee)
    {
        _database.Coffees.Add(coffee);
        await _database.SaveChangesAsync();

        return coffee;
    }

    public async Task UpdateCoffee(Coffee coffee)
    {
        _database.Update(coffee);
        await _database.SaveChangesAsync();
    }

    public async Task DeleteCoffee(Coffee coffee)
    {
        _database.Remove(coffee);
        await _database.SaveChangesAsync();
    }
}