namespace xcharge.Application.DTOs.Condominium.Responses;

public record AppUserSearchDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? CPF { get; set; }
}
