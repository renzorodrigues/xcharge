namespace xcharge.Application.Interfaces.Mappers;

public interface IMapper<TInput, TOutput>
{
    TOutput Map(TInput source);
}
