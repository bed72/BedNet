public class BaseEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
}