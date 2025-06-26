using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser User { get; set; } = null!;
}
