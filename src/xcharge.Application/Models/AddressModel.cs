using System.ComponentModel.DataAnnotations;

namespace xcharge.Application.ViewModel;

public record AddressModel
{
    [Required]
    public string? PublicArea { get; set; }

    [Required]
    public string? Number { get; set; }
    public string? Complement { get; set; }

    [Required]
    public string? District { get; set; }

    [Required]
    public string? ZipCode { get; set; }

    [Required]
    public string? State { get; set; }

    [Required]
    public string? City { get; set; }
}
