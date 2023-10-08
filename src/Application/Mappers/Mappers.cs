public interface IMapper<I, O>
{
    public O Mapper(I data);
}

public class ToEntityMapper : IMapper<CoffeeInModel, CoffeeEntity>
{
    public CoffeeEntity Mapper(CoffeeInModel data) => new(data.Name, data.Price);
}

public class ToModelMapper : IMapper<CoffeeEntity, CoffeeOutModel>
{
    public CoffeeOutModel Mapper(CoffeeEntity data) => new(
        data.Id,
        data.Name,
        data.Price,
        data.Created,
        data.Updated
    );
}