public class CoffeeInModel
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = double.E;
}

public class CoffeeOutModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = double.E;
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
}