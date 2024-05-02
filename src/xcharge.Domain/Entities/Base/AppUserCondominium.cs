using xcharge.Domain.Enums;

namespace xcharge.Domain.Entities.Base;

public class AppUserCondominium
{
    public AppUserCondominium() { }

    public AppUserCondominium(Guid appUserId, Guid condominiumId, UserType userType)
    {
        this.AppUserId = appUserId;
        this.CondominiumId = condominiumId;
        this.UserType = userType;
    }

    public Guid CondominiumId { get; private set; }
    public Condominium? Condominium { get; set; }
    public Guid AppUserId { get; private set; }
    public AppUser? AppUser { get; private set; }
    public UserType UserType { get; private set; }
}
