using Bed.Src.Domain.Entities;

namespace Bed.Src.Application.Models
{
    public record EmptyModel();

    public record CoffeeInModel(string Name, double Price)
    {
        public static explicit operator CoffeeEntity(CoffeeInModel model) => new()
        {
            Name = model.Name,
            Price = model.Price
        };
    }

    public record CoffeeOutModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = double.E;
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        public CoffeeOutModel()
        {
        }

        public CoffeeOutModel(Guid id, string name, double price, DateTime created, DateTime updated)
        {
            Id = id;
            Name = name;
            Price = price;
            Created = created;
            Updated = updated;
        }

        public static explicit operator CoffeeOutModel(CoffeeEntity entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Created = entity.Created,
            Updated = entity.Updated
        };
    }
}