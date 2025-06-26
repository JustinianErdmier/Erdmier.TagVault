using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser User { get; set; } = null!;
}
