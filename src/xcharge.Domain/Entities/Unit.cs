using xcharge.Domain.Entities.Base;

namespace xcharge.Domain.Entities;

public sealed class Unit : BaseEntity
{
    public Unit() { }

    public Unit(string? code, double size, bool isRented, Block? block, bool isForRent = false)
    {
        this.Code = code;
        this.Size = size;
        this.IsRented = isRented;
        this.IsForRent = isForRent;
    }

    public string? Code { get; private set; }
    public double Size { get; private set; }
    public Block? Block { get; private set; }
    public bool IsRented { get; private set; }
    public bool IsForRent { get; private set; }
    public bool IsDefaulter { get; private set; }
    public AppUser? Owner { get; private set; }
    public AppUser? Tenant { get; private set; }

    public void IsRentedUpdate(bool isRented)
    {
        this.IsRented = isRented;
        if (isRented)
            this.IsForRent = false;
    }
}
