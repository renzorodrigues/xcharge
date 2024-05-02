using System.Text.Json.Serialization;

namespace xcharge.Application.DTOs.BankSlip.Responses;

public class BankSlipIssueDto
{
    [JsonPropertyName("id_unico")]
    public string? UniqueId { get; set; }

    [JsonPropertyName("id_unico_original")]
    public string? OriginalUniqueId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("msg")]
    public string? Message { get; set; }

    [JsonPropertyName("nossonumero")]
    public string? OurNumber { get; set; }

    [JsonPropertyName("linkBoleto")]
    public string? BankSlipLink { get; set; }

    [JsonPropertyName("linkGrupo")]
    public string? GroupLink { get; set; }

    [JsonPropertyName("linhaDigitavel")]
    public string? TypeableLine { get; set; }

    [JsonPropertyName("banco_numero")]
    public string? BankNumber { get; set; }

    [JsonPropertyName("token_facilitador")]
    public string? FacilitatorToken { get; set; }

    [JsonPropertyName("credencial")]
    public string? Credential { get; set; }
}
