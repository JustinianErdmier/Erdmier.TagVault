﻿using Erdmier.TagVault.Domain.ApplicationUserAggregate.Entities;

using Microsoft.AspNetCore.Identity;

namespace Erdmier.TagVault.Domain.ApplicationUserAggregate;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<ApplicationUserClaim> Claims { get; set; } = new List<ApplicationUserClaim>();

    public ICollection<ApplicationUserLogin> Logins { get; set; } = new List<ApplicationUserLogin>();

    public ICollection<ApplicationUserToken> Tokens { get; set; } = new List<ApplicationUserToken>();

    public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}
