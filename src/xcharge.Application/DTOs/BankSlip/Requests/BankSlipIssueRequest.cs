using System.Text.Json.Serialization;

namespace xcharge.Application.DTOs.BankSlip.Requests;

public class BankSlipIssueRequest
{
    [JsonPropertyName("vencimento")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("valor")]
    public double? Amount { get; set; }

    [JsonPropertyName("juros")]
    public double? Interests { get; set; }

    // [JsonPropertyName("desconto")]
    // public string? Discount { get; set; }

    [JsonPropertyName("juros_fixo")]
    public double? FixedInterests { get; set; }

    [JsonPropertyName("multa")]
    public double? Fine { get; set; }

    [JsonPropertyName("multa_fixa")]
    public double? FixedFine { get; set; }

    [JsonPropertyName("nome_cliente")]
    public string? Name { get; set; }

    [JsonPropertyName("email_cliente")]
    public string? Email { get; set; }

    [JsonPropertyName("telefone_cliente")]
    public string? Telephone { get; set; }

    [JsonPropertyName("cpf_cliente")]
    public string? CPF { get; set; }

    [JsonPropertyName("endereco_cliente")]
    public string? PublicArea { get; set; }

    [JsonPropertyName("numero_cliente")]
    public string? Number { get; set; }

    [JsonPropertyName("bairro_cliente")]
    public string? District { get; set; }

    [JsonPropertyName("cidade_cliente")]
    public string? City { get; set; }

    [JsonPropertyName("estado_cliente")]
    public string? State { get; set; }

    [JsonPropertyName("cep_cliente")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("texto")]
    public string? Text { get; set; }

    [JsonPropertyName("instrucoes")]
    public string? Instructions { get; set; }

    [JsonPropertyName("instrucao_adicional")]
    public string? AdditionalInstructions { get; set; }

    [JsonPropertyName("grupo")]
    public string? Group { get; set; }

    [JsonPropertyName("webhook")]
    public string? Webhook { get; set; }

    [JsonPropertyName("pedido_numero")]
    public string? RequestNumber { get; set; }

    [JsonPropertyName("especie_documento")]
    public string? DocumentType { get; set; }
}
