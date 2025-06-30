using Erdmier.DomainCore.MediatorCore;
using Erdmier.TagVault.Domain.TagLinkAggregate;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Persistence.Common.Extensions;

namespace Persistence.Contexts;

public sealed class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
{
    public const string ConnectionStringKey = "ConnectionStrings:ApplicationDbContext";

    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
        => _publishDomainEventsInterceptor = publishDomainEventsInterceptor;

    public DbSet<Tag> Tags => Set<Tag>();

    public DbSet<TagLink> TagLinks => Set<TagLink>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<List<IDomainEvent>>();
        modelBuilder.ConfigureApplicationUserAggregate();
        modelBuilder.ConfigureTagAggregate();
        modelBuilder.ConfigureTagLinkAggregate();
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);

        base.OnConfiguring(optionsBuilder);
    }
}
