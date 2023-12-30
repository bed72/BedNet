using Moq;

using LanguageExt;

using System.Threading;
using System.Threading.Tasks;

using Bed.src.domain.entities;
using Bed.src.application.models;
using Bed.src.domain.repositories;
using Bed.src.application.usecases;

namespace Tests.src.application.usecases;

public class CreateUseCaseTest
{
    private ICreateUseCase _useCase;
    private Mock<IRepository> _repository;

    private CancellationToken _cancellationToken;
    private CancellationTokenSource _cancellationSource;

    private Task<Either<FailureEntity, CoffeeEntity>> _mock;

    [SetUp]
    public void Setup()
    {
        _cancellationSource = new();
        _cancellationToken = _cancellationSource.Token;

        _repository = new Mock<IRepository>();
        _useCase = new CreateUseCase(_repository.Object);

        _mock = new Either<FailureEntity, CoffeeEntity>().AsTask();
        _repository.Setup(repo => repo.Create(new CoffeeEntity(), _cancellationToken)).Returns(_mock);
    }

    [Test]
    public async Task ShouldCreateCoffeeWithSuccessfulReturnAsync()
    {
        CoffeeInModel parameter = new("Coffee Mock", 72);

        var response = await _useCase.Execute(parameter, _cancellationToken);

        Assert.That(response.IsRight, Is.True);
    }
}