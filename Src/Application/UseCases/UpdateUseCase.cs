using Bed.Src.Domain.Entities;
using Bed.Src.Domain.UseCases;
using Bed.Src.Application.Models;
using Bed.Src.Domain.Repositories;

namespace Bed.Src.Application.UseCases
{
    public interface IUpdateUseCase : IUseCase<CoffeeOutModel?, Tuple<Guid, CoffeeInModel>> { }

    public sealed class UpdateUseCase : IUpdateUseCase
    {
        private readonly IRepository _repository;

        public UpdateUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoffeeOutModel?> Execute(Tuple<Guid, CoffeeInModel> data)
        {
            CoffeeEntity? coffee = await _repository.GetById(data.Item1);

            if (coffee is null) return null;

            coffee.Name = data.Item2.Name;
            coffee.Price = data.Item2.Price;
            coffee.Updated = DateTime.Now.ToUniversalTime();

            CoffeeEntity response = await _repository.Update(coffee);
            CoffeeOutModel model = (CoffeeOutModel)response;

            return model;
        }
    }
}