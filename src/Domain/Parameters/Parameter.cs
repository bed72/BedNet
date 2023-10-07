using System.ComponentModel.DataAnnotations;

public class Parameter { }

public class GetParameter : Parameter
{
    public GetParameter(Guid id)
    {
        Id = id;
    }

    [Required]
    public Guid Id { get; set; }
}

public class DeleteParameter : Parameter
{
    public DeleteParameter(Guid id)
    {
        Id = id;
    }

    [Required]
    public Guid Id { get; set; }
}

public class CreateParameter : Parameter
{
    public CreateParameter(Coffee data)
    {
        Data = data;
    }

    [Required]
    public Coffee? Data { get; set; }
}

public class UpdateParameter : Parameter
{
    public UpdateParameter(Guid id, Coffee data)
    {
        Id = id;
        Data = data;
    }

    [Required]
    public Guid Id { get; set; }
    [Required]
    public Coffee? Data { get; set; }
}