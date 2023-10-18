using Bed.Src.Domain.UseCases;
using Bed.Src.Domain.Entities;
using Bed.Src.Application.Models;
using Bed.Src.Domain.Repositories;

namespace Bed.Src.Application.UseCases
{
    public interface IGetByIdUseCase : IUseCase<CoffeeOutModel?, Guid> { }

    public sealed class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly IRepository _repository;

        public GetByIdUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoffeeOutModel?> Execute(Guid data)
        {
            CoffeeEntity? response = await _repository.GetById(data);

            if (response is null) return null;

            CoffeeOutModel model = (CoffeeOutModel)response;

            return model;
        }
    }
}