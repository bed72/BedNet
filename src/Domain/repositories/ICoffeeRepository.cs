public interface ICoffeeRepository
{
    Task<List<Coffee>> GetCoffees();
    Task<Coffee?> GetCoffee(Guid id);
    Task<Coffee> CreateCoffee(Coffee coffee);
    Task UpdateCoffee(Coffee coffee);
    Task DeleteCoffee(Coffee coffee);
}