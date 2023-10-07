using AutoMapper;

public class ToEntityMapper : Profile
{
    public ToEntityMapper()
    {
        CreateMap<CoffeeInModel, CoffeeEntity>();
    }
}

public class ToModelMapper : Profile
{
    public ToModelMapper()
    {
        CreateMap<CoffeeEntity, CoffeeOutModel>();
    }
}