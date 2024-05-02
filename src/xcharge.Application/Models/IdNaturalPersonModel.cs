using System.ComponentModel.DataAnnotations;

namespace xcharge.Application.ViewModel;

public record IdNaturalPersonModel
{
    [Required]
    public string? Cpf { get; set; }

    public string? Rg { get; set; }

    public string? Pis { get; set; }
}
