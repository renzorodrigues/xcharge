using Microsoft.AspNetCore.Identity;

namespace xcharge.Domain.Entities;

public sealed class AccountUser : IdentityUser
{
    public AppUser? AppUser { get; private set; }
}
