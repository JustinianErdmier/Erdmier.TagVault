using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser User { get; set; } = null!;
}
