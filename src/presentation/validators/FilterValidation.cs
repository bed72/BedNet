using FluentValidation;
using FluentValidation.Results;

namespace Bed.src.application.validators;

public class FilterValidation<T>(IValidator<T> validator) : IEndpointFilter where T : class
{
    private readonly IValidator<T> _validator = validator;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (context.Arguments.FirstOrDefault(parameter => parameter?.GetType() == typeof(T)) is not T value)
            return Results.BadRequest();

        ValidationResult? data = await _validator.ValidateAsync(value);

        if (!data.IsValid) return Results.UnprocessableEntity(string.Join("/n", data.Errors));

        return await next(context);
    }
}