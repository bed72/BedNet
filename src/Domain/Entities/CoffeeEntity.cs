
public class CoffeeEntity : BaseEntity
{
    public CoffeeEntity(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = double.E;
}