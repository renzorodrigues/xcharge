using xcharge.Domain.Entities.Base;

namespace xcharge.Domain.Entities;

public sealed class Block : BaseEntity
{
    private Block() { }

    public Block(string? code, short? numberOfLifts, IEnumerable<Unit>? units)
    {
        this.Code = code;
        this.NumberOfLifts = numberOfLifts;
        this.Units = units;
    }

    public string? Code { get; private set; }
    public short? NumberOfLifts { get; private set; }
    public IEnumerable<Unit>? Units { get; private set; }
}
