using LanguageExt;
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

    public async Task<Either<FailureEntity, CoffeeEntity>> Create(CoffeeEntity parameter)
    {
        try
        {
            _database.Coffee.Add(parameter);
            await _database.SaveChangesAsync();

            return parameter;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar o café.");
        }
    }

    public async Task<Either<FailureEntity, CoffeeEntity>> GetById(Guid parameter)
    {
        try
        {
            CoffeeEntity? response = await _database.Coffee
                .AsNoTracking()
                .FirstOrDefaultAsync(value => value.Id == parameter);

            return response is not null
                ? response
                : new FailureEntity("Não encontramos o café.");
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar o café.");
        }
    }

    public async Task<Either<FailureEntity, List<CoffeeEntity>>> GetPaginete(int page, int limit)
    {
        try
        {
            int offset = (page - 1) * limit;

            List<CoffeeEntity>? response = await _database.Coffee
                .AsNoTracking()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return response is not null
                ? response
                : new FailureEntity("Não encontramos café registrado.");
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar os cafés.");
        }
    }

    public async Task<Either<FailureEntity, CoffeeEntity>> Update(Guid id, CoffeeEntity parameter)
    {
        try
        {
            // Either<FailureEntity, CoffeeEntity> response = await GetById(id);

            // if (response.IsLeft) return response;

            _database.Update(parameter);
            await _database.SaveChangesAsync();

            return parameter;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar atualizar o café.");
        }
    }

    public async Task<Either<FailureEntity, bool>> Delete(Guid parameter)
    {
        try
        {
            Either<FailureEntity, CoffeeEntity> response = await GetById(parameter);

            if (response.IsLeft)
                return response.Map(mapper: (_) => false).MapLeft(mapper: (failure) => failure);

            _database.Remove(parameter);
            await _database.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar deletar o café.");
        }
    }
}
