using LanguageExt;
using Microsoft.EntityFrameworkCore;

using Bed.src.domain.entities;
using Bed.src.domain.repositories;
using Bed.src.infrastructure.database;

namespace Bed.src.infrastructure.repositories;

public sealed class CoffeeEntityRepository(ConnectionDatabase database) : IRepository
{
    private readonly ConnectionDatabase _database = database;

    public async Task<Either<FailureEntity, CoffeeEntity>> Create(CoffeeEntity parameter, CancellationToken cancellation)
    {
        try
        {
            bool alreadyRegistered =
                await _database.Coffee.AnyAsync(coffee => coffee.Name == parameter.Name, cancellation);

            if (alreadyRegistered) return new FailureEntity("Este café já foi cadastrado.");

            parameter.Created = DateTime.Now.ToUniversalTime();

            await _database.Coffee.AddAsync(parameter, cancellation);
            await _database.SaveChangesAsync(cancellation);

            return parameter;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar o café.");
        }
    }

    public async Task<Either<FailureEntity, CoffeeEntity>> GetById(Guid parameter, CancellationToken cancellation)
    {
        try
        {
            CoffeeEntity? response = await _database.Coffee
                .AsNoTracking()
                .FirstOrDefaultAsync(value => value.Id == parameter, cancellation);

            return response is not null
                ? response
                : new FailureEntity("Não encontramos o café.");
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar o café.");
        }
    }

    public async Task<Either<FailureEntity, List<CoffeeEntity>>> GetPaginete(int page, int limit, CancellationToken cancellation)
    {
        try
        {
            int offset = (page - 1) * limit;

            List<CoffeeEntity>? response = await _database.Coffee
                .AsNoTracking()
                .Skip(offset)
                .Take(limit)
                .ToListAsync(cancellation);

            return response is not null
                ? response
                : new FailureEntity("Não encontramos o café registrado.");
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar encontrar os cafés.");
        }
    }

    public async Task<Either<FailureEntity, CoffeeEntity>> Update(Guid id, CoffeeEntity parameter, CancellationToken cancellation)
    {
        try
        {
            CoffeeEntity? response = await _database.Coffee.SingleOrDefaultAsync(coffee => coffee.Id == id, cancellation);

            if (response == null) return new FailureEntity("Não encontramos o café registrado.");

            response.Name = parameter.Name;
            response.Price = parameter.Price;
            response.Updated = DateTime.Now.ToUniversalTime();

            await _database.SaveChangesAsync(cancellation);

            return response;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar atualizar o café.");
        }
    }

    public async Task<Either<FailureEntity, bool>> Delete(Guid parameter, CancellationToken cancellation)
    {
        try
        {
            CoffeeEntity? response =
                await _database.Coffee.SingleOrDefaultAsync(coffee => coffee.Id == parameter, cancellation);

            if (response == null) return false;

            _database.Remove(response);
            await _database.SaveChangesAsync(cancellation);

            return true;
        }
        catch (Exception)
        {
            return new FailureEntity("Um erro ocorreu ao tentar deletar o café.");
        }
    }
}
