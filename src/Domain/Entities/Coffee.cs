using System.ComponentModel.DataAnnotations;

public class Coffee
{
    [Required]
    public Guid Id { get; set; }

    [Required, MinLength(2), MaxLength(16)]
    public string? Name { get; set; } = string.Empty;

    [Required]
    public double? Price { get; set; } = double.E;

    public DateTime? Created { get; set; } = DateTime.Now;

    public DateTime? Updated { get; set; } = DateTime.Now;
}