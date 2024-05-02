using System.ComponentModel.DataAnnotations;

namespace xcharge.Domain.ValueObjects;

public record IdNaturalPerson
{
    public IdNaturalPerson(string? cpf, string? rg, string? pis)
    {
        this.Cpf = cpf;
        this.Rg = rg;
        this.Pis = pis;
    }

    [Required]
    [MaxLength(11)]
    public string? Cpf { get; private set; }

    [MaxLength(14)]
    public string? Rg { get; private set; }

    [MaxLength(11)]
    public string? Pis { get; private set; }
}
