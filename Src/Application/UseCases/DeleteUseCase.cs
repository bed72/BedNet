using Bed.Src.Domain.Entities;
using Bed.Src.Domain.UseCases;
using Bed.Src.Domain.Repositories;

namespace Bed.Src.Application.UseCases
{
    public interface IDeleteUseCase : IUseCase<bool, Guid> { }

    public sealed class DeleteUseCase : IDeleteUseCase
    {
        private readonly IRepository _repository;

        public DeleteUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(Guid data)
        {
            CoffeeEntity? response = await _repository.GetById(data);

            if (response is null) return false;

            await _repository.Delete(response);

            return true;
        }
    }
}