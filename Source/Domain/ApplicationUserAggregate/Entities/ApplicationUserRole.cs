using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; set; } = null!;

    public ApplicationRole Role { get; set; } = null!;
}
