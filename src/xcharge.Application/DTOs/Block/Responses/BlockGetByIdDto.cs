using xcharge.Application.DTOs.Unit.Responses;

namespace xcharge.Application.DTOs.Block.Responses;

public class BlockGetByIdDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? NumberOfLifts { get; set; }
    public IEnumerable<UnitDto>? Units { get; set; }
}
