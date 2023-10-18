namespace Bed.Src.Application.Models
{
    public record FailureModel(string Message);

    public record FailuresModel(List<string> Messages);
}