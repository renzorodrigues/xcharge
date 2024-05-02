using Microsoft.AspNetCore.Mvc;
using xcharge.Domain.ValueObjects;
using xcharge.Shared.Helpers;

namespace xcharge.API.Controllers.v1;

[ApiController]
[Tags("Tools")]
[Route("api/[controller]")]
public class ToolController : ControllerBase
{
    [HttpGet("validate/{cnpj}")]
    public IActionResult ValidateCnpj(string cnpj)
    {
        var isValid = IdLegalPerson.IsValidCnpj(cnpj);
        return isValid ? Ok(new CnpjResult(isValid, cnpj)) : BadRequest(false);
    }
}
