using System.Reflection;

public interface IRepository
{
    Task<List<CoffeeEntity>> GetAll();
    Task<CoffeeEntity?> GetById(Guid id);
    Task<CoffeeEntity> Create(CoffeeEntity data);
    Task<CoffeeEntity> Update(CoffeeEntity data);
    Task Delete(CoffeeEntity data);
}