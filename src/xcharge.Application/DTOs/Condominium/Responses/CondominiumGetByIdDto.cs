namespace xcharge.Application.DTOs.Condominium.Responses;

public record CondominiumGetByIdDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? IdCnpj { get; set; }
    public string? AddressPublicArea { get; set; }
    public string? AddressNumber { get; set; }
    public string? AddressComplement { get; set; }
    public string? AddressDistrict { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressState { get; set; }
    public string? AddressZipCode { get; set; }
    public string? Email { get; set; }
    public string? IdCityRegistration { get; set; }
    public string? IdStateRegistration { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
}
