public class CoffeeInModel
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = double.E;
}

public class CoffeeOutModel
{
    public CoffeeOutModel(Guid id, string name, double price, DateTime created, DateTime updated)
    {
        Id = id;
        Name = name;
        Price = price;
        Created = created;
        Updated = updated;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = double.E;
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
}