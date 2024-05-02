using System.ComponentModel.DataAnnotations;

namespace xcharge.Domain.ValueObjects;

public record Telephone
{
    public Telephone(string landline, string mobile)
    {
        this.Landline = landline;
        this.Mobile = mobile;
    }

    [MaxLength(10)]
    public string? Landline { get; private set; }

    [Required]
    [MaxLength(11)]
    public string? Mobile { get; private set; }
}
