using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationRole Role { get; set; } = null!;
}
