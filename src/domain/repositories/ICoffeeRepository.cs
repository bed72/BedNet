using Bed.src.domain.entities;

namespace Bed.src.domain.repositories;

public interface IRepository
{
    Task<List<CoffeeEntity>> GetAll(Tuple<int, int> data);
    Task<CoffeeEntity?> GetById(Guid id);
    Task<CoffeeEntity> Create(CoffeeEntity data);
    Task<CoffeeEntity> Update(CoffeeEntity data);
    Task Delete(CoffeeEntity data);
}
