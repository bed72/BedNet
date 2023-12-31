using Bed.src.domain.entities;

namespace Bed.src.application.models;

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
    public Guid? Id { get; set; } = null;
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = 0.0;
    public DateTime? Created { get; set; } = null;
    public DateTime? Updated { get; set; } = null;

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
