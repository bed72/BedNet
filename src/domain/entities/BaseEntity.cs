namespace Bed.src.domain.entities;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime? Created { get; set; } = null;
    public DateTime? Updated { get; set; } = null;
}