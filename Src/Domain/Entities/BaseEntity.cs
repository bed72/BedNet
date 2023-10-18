namespace Bed.Src.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime Updated { get; set; } = DateTime.Now.ToUniversalTime();
    }
}