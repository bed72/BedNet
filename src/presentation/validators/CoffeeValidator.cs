using FastEndpoints;
using FluentValidation;

using Bed.src.application.models;

namespace Bed.src.application.validators;

public class CoffeeValidator : Validator<CoffeeInModel>
{
    public CoffeeValidator()
    {
        RuleFor(coffee => coffee.Name)
            .NotEmpty()
            .WithMessage("Informe um nome.");
        RuleFor(coffee => coffee.Price)
            .GreaterThan(0)
            .WithMessage("O preço precisar ser maior que R$ 0,0");
    }
}
