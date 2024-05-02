using System.ComponentModel.DataAnnotations;

namespace xcharge.Domain.ValueObjects;

public record Email
{
    public Email(string? emailAddress)
    {
        this.EmailAddress = emailAddress;
    }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? EmailAddress { get; private set; }
}
