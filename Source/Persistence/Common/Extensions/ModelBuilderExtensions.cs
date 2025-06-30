using Erdmier.TagVault.Domain.TagLinkAggregate;

using Persistence.Configurations;

namespace Persistence.Common.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureApplicationUserAggregate(this ModelBuilder modelBuilder)
    {
        new ApplicationUserConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
        new ApplicationRoleConfiguration().Configure(modelBuilder.Entity<ApplicationRole>());
        new ApplicationUserRoleConfiguration().Configure(modelBuilder.Entity<ApplicationUserRole>());
        new ApplicationUserClaimConfiguration().Configure(modelBuilder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginConfiguration().Configure(modelBuilder.Entity<ApplicationUserLogin>());
        new ApplicationUserTokenConfiguration().Configure(modelBuilder.Entity<ApplicationUserToken>());
        new ApplicationRoleClaimConfiguration().Configure(modelBuilder.Entity<ApplicationRoleClaim>());
    }

    public static void ConfigureTagAggregate(this ModelBuilder modelBuilder) => new TagConfiguration().Configure(modelBuilder.Entity<Tag>());

    public static void ConfigureTagLinkAggregate(this ModelBuilder modelBuilder) => new TagLinkConfiguration().Configure(modelBuilder.Entity<TagLink>());
}
