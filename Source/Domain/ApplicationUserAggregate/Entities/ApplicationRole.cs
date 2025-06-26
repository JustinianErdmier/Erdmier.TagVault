using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole()
    { }

    public ApplicationRole(string roleName)
        : base(roleName)
    { }

    public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();

    public ICollection<ApplicationRoleClaim> RoleClaims { get; set; } = new List<ApplicationRoleClaim>();
}
