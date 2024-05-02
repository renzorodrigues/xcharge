using System.ComponentModel.DataAnnotations;

namespace xcharge.Domain.ValueObjects;

public record Address
{
    public Address(
        string? publicArea,
        string? number,
        string? complement,
        string? district,
        string? zipCode,
        string? state,
        string? city
    )
    {
        this.PublicArea = publicArea;
        this.Number = number;
        this.Complement = complement;
        this.District = district;
        this.ZipCode = zipCode;
        this.State = state;
        this.City = city;
    }

    [Required]
    [MaxLength(100)]
    public string? PublicArea { get; private set; }

    [Required]
    [MaxLength(10)]
    public string? Number { get; private set; }

    [MaxLength(100)]
    public string? Complement { get; private set; }

    [Required]
    [MaxLength(50)]
    public string? District { get; private set; }

    [Required]
    [MaxLength(9)]
    public string? ZipCode { get; private set; }

    [Required]
    [MaxLength(2)]
    public string? State { get; private set; }

    [Required]
    [MaxLength(50)]
    public string? City { get; private set; }
}
