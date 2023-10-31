using Bed.src.domain.entities;

namespace Bed.src.application.models;

public record FailuresOutModel(List<string> Messages);


public record FailureOutModel
{
    public string Message { get; set; } = string.Empty;

    public FailureOutModel() { }

    public FailureOutModel(string message)
    {
        Message = message;
    }

    public static explicit operator FailureOutModel(FailureEntity entity) => new()
    {
        Message = entity.Message,
    };
}

