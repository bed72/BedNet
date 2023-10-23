namespace Bed.src.application.models;

public record FailureModel(string Message);

public record FailuresModel(List<string> Messages);
