using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.ViewModel;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class EmailMapper : IEmailMapper
{
    public Email Map(EmailModel? source)
    {
        return new Email(source?.EmailAddress);
    }
}
