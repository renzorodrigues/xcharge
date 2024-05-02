using xcharge.Application.DTOs.Block.Responses;
using xcharge.Application.DTOs.Unit.Responses;
using xcharge.Application.Extensions;
using xcharge.Application.Interfaces.Mappers.Responses;

namespace xcharge.Application.Mappers.Block.Responses;

public class BlockGetByIdMapper : IBlockGetByIdMapper
{
    public BlockGetByIdDto Map(Domain.Entities.Block entity)
    {
        return new BlockGetByIdDto()
        {
            Id = entity.Id,
            NumberOfLifts = entity.NumberOfLifts.ToString(),
            Code = entity.Code,
            Units = Map(entity.Units!),
        };
    }

    public static IEnumerable<UnitDto> Map(IEnumerable<Domain.Entities.Unit> entities)
    {
        IEnumerable<UnitDto> responses;

        if (entities.IsNullOrEmpty())
        {
            return [];
        }

        responses = entities.Select(x => new UnitDto()
        {
            Id = x.Id,
            Code = x.Code,
            IsForRent = x.IsForRent,
            IsRented = x.IsRented,
            Size = x.Size.ToString(),
        });

        return responses;
    }
}
